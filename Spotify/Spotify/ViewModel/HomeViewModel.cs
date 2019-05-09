using System.Collections.ObjectModel;
using Spotify.Models;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using System;

namespace Spotify.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand SearchArtistsCommand { get; private set; }

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
            set {
                _icon = value;
                OnPropertyChanged("Icon");
            }
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
        public HomeViewModel()
        {
            Icon = "settings_" + GetCurrentTheme().ToLower() + ".png";
            SearchArtistsCommand = new Command(async () => await _SearchArtists(SearchText), () => !IsLoading);
        }
    }
}
