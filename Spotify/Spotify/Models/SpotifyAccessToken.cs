﻿using System;

namespace Spotify.Models
{
    public class SpotifyAccessToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public long expires_in { get; set; }
    }
}
