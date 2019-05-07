using System;
using System.Collections.ObjectModel;
using Spotify.Models;

namespace Spotify.ViewModel
{
    public class DetailViewModel : BaseViewModel
    {
        public Image ImageArtist { get; set; }

        public string Name { get; set; }

        private ObservableCollection<Track> _tracks = new ObservableCollection<Track>();

        public ObservableCollection<Track> Tracks
        {
            get { return _tracks; }
            set { _tracks = value; }
        }        

        /// <summary>
        /// Sets artist's info
        /// </summary>
        /// <param name="artist"></param>
        private void _SetInfoArtist(Artist artist)
        {
            Name = artist.Name;
            ImageArtist = artist.MainImage;
            _GetTracks(artist.Id);
        }
        
        /// <summary>
        /// Gets the top tracks of an artist
        /// </summary>
        /// <param name="artistId"></param>
        private async void _GetTracks(string artistId)
        {
            try
            {
                IsLoading = true;
                var topTracks = await SpotifyAPI.GetTopTracks(artistId);
                if (topTracks != null && topTracks.Count > 0)
                {
                    foreach (Track track in topTracks)
                    {
                        Tracks.Add(track);
                    }
                }
                IsLoading = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Populate Tracks");
                Console.WriteLine(e.Message);
            }
        }

        public DetailViewModel(Artist artist)
        {
            _SetInfoArtist(artist);
        }
    }
}
