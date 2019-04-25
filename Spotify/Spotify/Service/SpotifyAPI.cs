﻿using System;
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
        private HttpClient _client;
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

        public async Task<List<Artist>> GetArtists()
        {
            string GET_ARTIST = "/search?q=rock&type=artist&limit=20&offset=0";
            SpotifyAccessToken Token = await GetToken();

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Token.token_type, Token.access_token);

            var response = await _client.GetAsync(BASE_URL + GET_ARTIST);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonArtists = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ArtistResult>(jsonArtists).Artists.Items;
                return result;
            }
            return default(List<Artist>);
        }

        //public async Task<List<Artist>> GetTopTracks(Artist artist)
        //{
        //    string GET_TRACKS = "/artists/" + artist.Id + "/top-tracks";
        //    SpotifyAccessToken Token = await GetToken();

        //    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Token.token_type, Token.access_token);

        //    var response = await _client.GetAsync(BASE_URL + GET_TRACKS);

        //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        var jsonArtists = await response.Content.ReadAsStringAsync();
        //        var result = JsonConvert.DeserializeObject<ArtistResult>(jsonArtists).Artists.Items;
        //        return result;
        //    }
        //    return default(List<Artist>);
        //}
    }
}
