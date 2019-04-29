using System;
using System.Collections.Generic;

namespace Spotify.Models
{
    public class Album
    {
        public string Album_type { get; set; }
        public List<Artist> Artists { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        private List<Image> _images;
        public List<Image> Images
        {
            get { return _images; }
            set { _images = value; }
        }
        public string Name { get; set; }
        public string Release_date { get; set; }
        public string Release_date_precision { get; set; }
        public int Total_tracks { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
        private Image _albumImage;
        public Image AlbumImage
        {
            get
            {
                double max = _images.Count;
                int index = 0;
                if (max > 0)
                {
                    index = Convert.ToInt32(Math.Ceiling(max / 2));
                    _albumImage = _images[index - 1];
                }
                return _albumImage;
            }
            set
            {
                _albumImage = value;
            }
        }
    }
}
