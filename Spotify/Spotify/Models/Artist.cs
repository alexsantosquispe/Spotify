using System;
using System.Collections.Generic;

namespace Spotify.Models
{
    public class Artist
    {
        public List<object> Genres { get; set; }
        public string Id { get; set; }
        public List<Image> Images { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}
