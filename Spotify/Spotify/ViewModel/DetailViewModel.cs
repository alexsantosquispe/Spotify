using System;
using System.Collections.ObjectModel;
using Spotify.Models;
using Spotify.Service;

namespace Spotify.ViewModel
{
    public class DetailViewModel : BaseViewModel
    {
        private readonly SpotifyAPI _spotifyAPI = new SpotifyAPI();

        public Image ImageArtist { get; set; }

        public string Name { get; set; }

        private ObservableCollection<Track> _tracks = new ObservableCollection<Track>();

        public ObservableCollection<Track> Tracks
        {
            get { return _tracks; }
            set { _tracks = value; }
        }

        public DetailViewModel(Artist artist)
        {
            _SetInfoArtist(artist);
        }

        private void _SetInfoArtist(Artist artist)
        {
            Name = artist.Name;
            ImageArtist = artist.MainImage;
            _GetTracks(artist.Id);
        }

        private async void _GetTracks(string artistId)
        {
            try
            {
                IsLoading = true;
                var topTracks = await _spotifyAPI.GetTopTracks(artistId);
                if (topTracks != null && topTracks.Count > 0) {
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
    }
}
