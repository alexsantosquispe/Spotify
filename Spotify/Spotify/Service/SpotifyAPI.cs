using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Spotify.Models;

namespace Spotify.Service
{
    public class SpotifyAPI
    {
        private const string BASE_URL = "https://api.spotify.com/v1";
        private const string TOKEN_URL = "https://accounts.spotify.com/api/token";
        HttpClient Client = new HttpClient();

        public async Task<SpotifyAccessToken> GetToken()
        {
            string ClientId = "e17a0b97649a49058fb90483a7802d54";
            string ClientSecret = "0efa0ca1a2ad42a2b25233b8ff50192a";
            string Credentials = String.Format("{0}:{1}", ClientId, ClientSecret);

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(Credentials)));

            //Prepare Request Body
            List<KeyValuePair<string, string>> RequestData = new List<KeyValuePair<string, string>>();
            RequestData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

            FormUrlEncodedContent RequestBody = new FormUrlEncodedContent(RequestData);

            //Request Token
            var RequesToken = await Client.PostAsync(TOKEN_URL, RequestBody);
            string Response = await RequesToken.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SpotifyAccessToken>(Response);
        }

        public async Task<T> GetArtists<T>(string url)
        {
            try
            {
                SpotifyAccessToken Token = await GetToken();
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Token.token_type, Token.access_token);

                var response = await Client.GetAsync(url);
                var jsonResult = "";
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        jsonResult = await response.Content.ReadAsStringAsync();
                        break;
                    case System.Net.HttpStatusCode.Unauthorized:
                        jsonResult = "";
                        break;
                }
                return JsonConvert.DeserializeObject<T>(jsonResult);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return default(T);
        }    
    }
}
