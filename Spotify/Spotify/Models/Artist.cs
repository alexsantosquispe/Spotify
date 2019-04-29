using System;
using System.Collections.Generic;

namespace Spotify.Models
{
    public class Artist
    {
        public List<object> Genres { get; set; }
        public string Id { get; set; }
        private List<Image> _images;
        public List<Image> Images
        {
            get { return _images; }
            set { _images = value; }
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
        private Image _mainImage;
        public Image MainImage
        {
            get
            {
                double max = _images.Count;
                int index = 0;
                if (max > 0)
                {
                    index = Convert.ToInt32(Math.Ceiling(max / 2));
                    _mainImage = _images[index - 1];
                }
                else
                {
                    _mainImage = new Image();
                    _mainImage.Url = "user_loading.png";
                }
                return _mainImage;
            }
            set
            {
                _mainImage = value;
            }
        }
    }
}
