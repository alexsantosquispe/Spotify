using System.Collections.Generic;

namespace Spotify.Models
{
    public class Album
    {
        public string Album_type { get; set; }
        public List<Artist> Artists { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public List<Image> Images { get; set; }
        public string Name { get; set; }
        public string Release_date { get; set; }
        public string Release_date_precision { get; set; }
        public int Total_tracks { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}
