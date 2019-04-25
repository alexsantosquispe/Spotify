using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Spotify.Service;
using Spotify.Models;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Spotify.ViewModel
{
    public class ArtistViewModel : BaseViewModel
    {
        private readonly SpotifyAPI _spotifyAPI = new SpotifyAPI();

        private ObservableCollection<Artist> artists = new ObservableCollection<Artist>();

        public ObservableCollection<Artist> Artists
        {
            get { return artists; }
            set { artists = value; }
        }

        private bool _isLoading = false;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; }
        }

        public ArtistViewModel()
        {
            _PopulateArtists();
            IsLoading = false;
        }

        private async void _PopulateArtists()
        {
            try
            {
                IsLoading = true;
                var artistList = await _spotifyAPI.GetArtists();
                foreach (Artist artist in artistList)
                {
                    Artists.Add(artist);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Populate Artists");
                Console.WriteLine(e.Message);
            }
        }
    }
}
