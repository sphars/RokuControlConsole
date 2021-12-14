using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using RokuControlConsole.Models;

namespace RokuControlConsole.Data
{
    public static class RokuClient
    {
        private static HttpClient client = new();

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

        public static void SendRokuCommand(RokuCommand command)
        {

            Uri url = new(RokuConfig.BaseUrl + command.Path);

            var t = Task.Run(() => PostCommand(url, ""));
            t.Wait();

            Console.WriteLine(t.Result);
        }


        public static async Task<string> GetRokuInformation(Uri uri)
        {
            string response;

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = uri,
                Content = new StringContent("")
            };

            HttpResponseMessage result = await client.SendAsync(request);

            if (result.IsSuccessStatusCode)
                response = await result.Content.ReadAsStringAsync();
            else
                response = "error";

            return response;
        }
    }
}
