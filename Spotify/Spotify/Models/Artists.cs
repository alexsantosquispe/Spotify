using System;
using System.Collections.Generic;

namespace Spotify.Models
{
    public class Artists
    {
        public string Href { get; set; }
        public List<Artist> Items { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
        public int Offset { get; set; }
        public object Previous { get; set; }
        public int Total { get; set; }
    }
}
