using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Ejemplo_Xbox_Music
{
    public static class Extensions
    {
        public static Task<Stream> GetRequestStreamAsync(this WebRequest wr)
        {
            if (wr.ContentLength < 0)
            {
                throw new InvalidOperationException(
                    "The ContentLength property of the WebRequest must first be set to the length of the content to be written to the stream.");
            }

            return Task<Stream>.Factory.FromAsync(wr.BeginGetRequestStream, wr.EndGetRequestStream, null);
        }

        public static Task<WebResponse> GetResponseAsync(this WebRequest wr)
        {
            return Task<WebResponse>.Factory.FromAsync(wr.BeginGetResponse, wr.EndGetResponse, null);
        }
    }
}