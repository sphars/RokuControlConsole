using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace RokuControlConsole
{
    public static class RokuClient
    {
        private static HttpClient client = new HttpClient();

        public static async Task<string> PostCommand(Uri uri, string content)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = uri,
                Content = new StringContent(content)
            };

            HttpResponseMessage result = await client.SendAsync(request);

            string response;
            if (result.IsSuccessStatusCode)
                response = result.StatusCode.ToString();
            else
                response = "error";

            return response;            
        }
    }
}
