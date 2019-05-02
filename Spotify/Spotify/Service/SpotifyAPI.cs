using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Spotify.Models;
using Spotify.Utils;

namespace Spotify.Service
{
    public class SpotifyAPI
    {
        private HttpClient _client;
        private readonly Network _network = new Network();
        private const string BASE_URL = "https://api.spotify.com/v1";
        private const string TOKEN_URL = "https://accounts.spotify.com/api/token";
        private const string CLIENT_ID = "e17a0b97649a49058fb90483a7802d54";
        private const string CLIENT_SECRET = "0efa0ca1a2ad42a2b25233b8ff50192a";

        public SpotifyAPI()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<SpotifyAccessToken> GetToken()
        {            
            string Credentials = String.Format("{0}:{1}", CLIENT_ID, CLIENT_SECRET);

            if (_network.IsConnected())
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(Credentials)));

                //Prepare Request Body
                List<KeyValuePair<string, string>> RequestData = new List<KeyValuePair<string, string>>();
                RequestData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

                FormUrlEncodedContent RequestBody = new FormUrlEncodedContent(RequestData);

                //Request Token
                var RequesToken = await _client.PostAsync(TOKEN_URL, RequestBody);
                string Response = await RequesToken.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SpotifyAccessToken>(Response);
            }
            return default(SpotifyAccessToken);
        }

        public async Task<List<Artist>> GetArtists(string word)
        {
            string GET_ARTIST = "/search?q=" + word + "&type=artist&market=US&limit=20&offset=0";
            GET_ARTIST = GET_ARTIST.Replace(" ", "%20");
            if (_network.IsConnected())
            {
                SpotifyAccessToken Token = await GetToken();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Token.token_type, Token.access_token);

                var response = await _client.GetAsync(BASE_URL + GET_ARTIST);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonArtists = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ArtistResult>(jsonArtists).Artists.Items;
                    return result;
                }                
            }
            return default(List<Artist>);
        }

        public async Task<List<Track>> GetTopTracks(string id)
        {
            string GET_TRACKS = "/artists/" + id + "/top-tracks?country=US";

            if (_network.IsConnected())
            {
                SpotifyAccessToken Token = await GetToken();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Token.token_type, Token.access_token);

                var response = await _client.GetAsync(BASE_URL + GET_TRACKS);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonArtists = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<CollectionTracks>(jsonArtists).Tracks;
                    return result;
                }
            }            
            return default(List<Track>);
        }
    }
}
