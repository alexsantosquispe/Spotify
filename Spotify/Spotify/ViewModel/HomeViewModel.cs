using System.Collections.ObjectModel;
using Spotify.Models;
using Xamarin.Forms;
using System.Windows.Input;
using Spotify.Service;
using System.Threading.Tasks;
using System;

namespace Spotify.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly SpotifyAPI _spotifyAPI = new SpotifyAPI();

        private ObservableCollection<Artist> artists = new ObservableCollection<Artist>();

        public ObservableCollection<Artist> Artists
        {
            get { return artists; }
            set
            {
                artists = value;
                OnPropertyChanged("Artists");
            }
        }

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged("_searchText");
            }
        }

        private string _icon;

        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public ICommand SearchArtistsCommand { get; private set; }

        public async Task _SearchArtists(string query)
        {
            try
            {
                IsLoading = true;
                var artistList = await _spotifyAPI.GetArtists(query.ToLower());
                if (artistList != null && artistList.Count > 0)
                {                    
                    Artists.Clear();
                    foreach (Artist artist in artistList)
                    {
                        Artists.Add(artist);
                    }
                }
                IsLoading = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Populate Artists");
                Console.WriteLine(e.Message);
            }
        }

        public HomeViewModel()
        {
            Icon = "settings_" + GetCurrentTheme().ToLower() + ".png";
            SearchArtistsCommand = new Command(async () => await _SearchArtists(SearchText), () => !IsLoading);
        }
    }
}
