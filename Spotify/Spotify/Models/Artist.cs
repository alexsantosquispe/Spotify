using System;
using System.Collections.Generic;

namespace Spotify.Models
{
    public class ExternalUrls
    {
        public string Spotify { get; set; }
    }

    public class Followers
    {
        public object Href { get; set; }
        public int Total { get; set; }
    }

    public class ImageArtist
    {
        public int Height { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
    }

    public class Artist
    {
        public ExternalUrls External_urls { get; set; }
        public Followers Followers { get; set; }
        public List<object> Genres { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public List<ImageArtist> Images { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}
