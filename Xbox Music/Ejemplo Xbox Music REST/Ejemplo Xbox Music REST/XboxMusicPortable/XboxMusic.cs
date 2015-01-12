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

    public class XboxMusic : IXboxMusic
    {
        private RestClient _client;

        public string ClientId { get; set; }
        public string ClientScecret { get; set; }
        public Token Token { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }

        public async Task<bool> Authenticate()
        {
            _client = new RestClient
            {
                BaseUrl = "https://datamarket.accesscontrol.windows.net"
            };

            var request = new RestRequest("v2/OAuth2-13", HttpMethod.Post)
            {
                ContentType = ContentTypes.FormUrlEncoded,
                ReturnRawString = true,
            };
            request.AddParameter("client_id", ClientId);
            request.AddParameter("client_secret", ClientScecret);
            request.AddParameter("scope", "http://music.xboxlive.com");
            request.AddParameter("grant_type", "client_credentials");

            string result = await _client.ExecuteAsync<string>(request);

            Token = JsonConvert.DeserializeObject<Token>(result);
            if (Token != null)
            {
                Token.TimeStamp = DateTime.Now;

                return true;
            }

            return false;
        }

        public async Task<ContentResponse> Find(string query, int maxItems = 25, bool getArtists = true,
            bool getAlbums = true, bool getTracks = true)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentNullException("query");

            if (maxItems > 25)
                throw new ArgumentOutOfRangeException("maxItems");

            await Authenticate();

            RestRequest request = GetPopulatedRequest("1/content/{namespace}/search");

            request.AddQueryString("q", query);

            if (maxItems != 25)
            {
                request.AddQueryString("maxItems", maxItems);
            }

            if (!(getArtists && getAlbums && getTracks))
            {
                var filter = new List<string>();

                if (getArtists) filter.Add("artists");
                if (getAlbums) filter.Add("albums");
                if (getTracks) filter.Add("tracks");

                request.AddQueryString("filters", filter.Aggregate("", (c, n) => c.Length == 0 ? c + n : c + ("+" + n)));
            }

            request.AddQueryString("accessToken", "Bearer " + Token.AccessToken);

            return await _client.ExecuteAsync<ContentResponse>(request);
        }

        private RestRequest GetPopulatedRequest(string resourceUrl)
        {
            if (string.IsNullOrWhiteSpace(Token.AccessToken))
            {
                throw new Exception("Unable to obtain an AccessToken.");
            }

            var request = new RestRequest(resourceUrl) {ContentType = ContentTypes.Json};

            request.AddUrlSegment("namespace", "music");

            if (!string.IsNullOrWhiteSpace(Language))
                request.AddQueryString("language", Language);

            if (!string.IsNullOrWhiteSpace(Country))
                request.AddQueryString("country", Country);

            return request;
        }
    }
}