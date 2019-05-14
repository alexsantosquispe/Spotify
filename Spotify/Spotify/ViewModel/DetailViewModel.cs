using System;
using System.Collections.ObjectModel;
using Spotify.Models;
using Spotify.Service;
using Xamarin.Forms;

namespace Spotify.ViewModel
{
    public class DetailViewModel : BaseViewModel
    {
        private readonly IPlayerManager _playerManager = DependencyService.Get<IPlayerManager>();

        public Models.Image ImageArtist { get; set; }

        public string Name { get; set; }

        private ObservableCollection<Track> _tracks = new ObservableCollection<Track>();

        public ObservableCollection<Track> Tracks
        {
            get { return _tracks; }
            set { _tracks = value; }
        }

        private Track _selectedTrack;

        public Track SelectedTrack
        {
            get { return _selectedTrack; }
            set {
                _selectedTrack = value;
                Play();
            }
        }

        /// <summary>
        /// Plays a track selected
        /// </summary>
        public void Play()
        {
            if(SelectedTrack != null && SelectedTrack.Preview_url != null)
            {
                _playerManager.Play(SelectedTrack.Preview_url);
            }
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

        /// <summary>
        /// Initializes properties
        /// </summary>
        /// <param name="artist"></param>
        public DetailViewModel(Artist artist)
        {
            _SetInfoArtist(artist);
        }
    }
}
