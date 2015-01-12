using System.Diagnostics;

namespace Ejemplo_Xbox_Music.Services
{
    using Model;
    using Newtonsoft.Json;
    using PortableRest;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class XboxMusic : RestClient, IXboxMusic
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        private TokenResult TokenResponse { get; set; }

        public XboxMusic()
        {
            BaseUrl = "https://music.xboxlive.com";
        }

        public async Task<XboxMusicResult> Find(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentNullException("query");

            if (TokenResponse == null || !TokenResponse.IsValid)
                await Authenticate();

            var request = GetPopulatedRequest("1/content/{namespace}/search");

            request.AddQueryString("q", query);

            request.AddQueryString("maxItems", 25);

            var filter = new List<string> { "artists", "albums", "tracks" };

            request.AddQueryString("filters", filter.Aggregate("", (c, n) => c.Length == 0 ? c += n : c += "+" + n));

            request.AddQueryString("accessToken", "Bearer " + TokenResponse.AccessToken);

            return await ExecuteAsync<XboxMusicResult>(request);
        }


        private RestRequest GetPopulatedRequest(string resourceUrl)
        {
            if (string.IsNullOrWhiteSpace(TokenResponse.AccessToken))
                throw new Exception();

            var request = new RestRequest(resourceUrl) { ContentType = ContentTypes.Json };

            request.AddUrlSegment("namespace", "music");

            return request;
        }

        private async Task Authenticate()
        {
            var client = new RestClient
            {
                BaseUrl = "https://datamarket.accesscontrol.windows.net",
                UserAgent = UserAgent,
            };
            var request = new RestRequest("v2/OAuth2-13", HttpMethod.Post)
            {
                ContentType = ContentTypes.FormUrlEncoded,
                ReturnRawString = true,
            };
            request.AddParameter("client_id", ClientId);
            request.AddParameter("client_secret", ClientSecret);
            request.AddParameter("scope", "http://music.xboxlive.com");
            request.AddParameter("grant_type", "client_credentials");

            var result = await client.ExecuteAsync<string>(request);

            TokenResponse = JsonConvert.DeserializeObject<TokenResult>(result);
            if (TokenResponse != null)
            {
                TokenResponse.TimeStamp = DateTime.Now;
            }
        }
    }
}