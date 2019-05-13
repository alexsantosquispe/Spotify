using System.Collections.ObjectModel;
using Spotify.Models;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using System;
using Spotify.Views;

namespace Spotify.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand SearchArtistsCommand { get; private set; }

        public ICommand GoToSettingsCommand { get; private set; }

        private INavigation _navigation;

        private ObservableCollection<Artist> _artists = new ObservableCollection<Artist>();

        public ObservableCollection<Artist> Artists
        {
            get { return _artists; }
            set
            {
                _artists = value;
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
            set
            {
                _icon = "settings_" + GetCurrentTheme().ToLower() + ".png";
                OnPropertyChanged("Icon");
            }
        }

        /// <summary>
        /// Goes To Settings Page
        /// </summary>        
        private async void GoToSettings()
        {
            await _navigation.PushAsync(new SettingsPage());
        }

        /// <summary>
        /// Populates the list of artists refer to query
        /// </summary>
        /// <param name="query">string variable to artist searching</param>
        /// <returns></returns>
        public async Task _SearchArtists(string query)
        {
            try
            {
                IsLoading = true;
                var artistList = await SpotifyAPI.GetArtists(query.ToLower());
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

        /// <summary>
        /// Initializes properties
        /// </summary>
        public HomeViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Icon = "settings_" + GetCurrentTheme().ToLower() + ".png";
            SearchArtistsCommand = new Command(async () => await _SearchArtists(SearchText), () => !IsLoading);
            GoToSettingsCommand = new Command(GoToSettings);
        }
    }
}
