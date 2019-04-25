using System.Collections.Generic;

namespace Spotify.Models
{
    public class Track
    {
        public Album Album { get; set; }
        public List<Artist> Artists { get; set; }
        public int Disc_number { get; set; }
        public int Duration_ms { get; set; }
        public bool Explicit { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public bool Is_local { get; set; }
        public bool Is_playable { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public string Preview_url { get; set; }
        public int Track_number { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }    
}
