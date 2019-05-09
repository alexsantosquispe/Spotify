using System.ComponentModel;
using System.Runtime.CompilerServices;
using Spotify.Service;
using Spotify.Themes;
using Spotify.Utils;
using Xamarin.Forms;

namespace Spotify.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public readonly IFirebaseAuth FirebaseAuth = new FireBaseAuth();
        public readonly ISpotifyAPI SpotifyAPI = new SpotifyAPI();

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Event to check what propertie has changed
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Gets the current theme saved
        /// </summary>
        /// <returns>An string with the current theme</returns>
        public string GetCurrentTheme()
        {
            string theme = "";
            if (Application.Current.Properties.ContainsKey("Theme"))
            {
                theme = Application.Current.Properties["Theme"].ToString();
            }
            return theme;
        }

        /// <summary>
        /// Sets the current theme to default theme
        /// </summary>
        public void SetCurrentTheme(string theme)
        {
            if (Theme != theme)
            {
                ThemeManager.ChangeTheme(theme);
                Theme = theme;
            }
        }

        /// <summary>
        /// Gets the email of the current session
        /// </summary>
        /// <returns>A string with the email</returns>
        public string GetCurrentEmailUser()
        {
            string emailUser = "";
            if (Application.Current.Properties.ContainsKey("Email"))
            {
                emailUser = Application.Current.Properties["Email"].ToString();
            }
            return emailUser;
        }

        private bool _isLoading = false;

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }

        private bool _isOffline = !Network.Connectivity.IsConnected;

        public bool IsOffline
        {
            get { return _isOffline; }
            set
            {
                _isOffline = value;
                OnPropertyChanged("IsOffline");
            }
        }

        private string _theme;

        public string Theme
        {
            get { return _theme; }
            set
            {
                _theme = value;
                OnPropertyChanged("Theme");
            }
        }

        /// <summary>
        /// Constructor of BaseViewModel Class
        /// </summary>
        public BaseViewModel()
        {
            Network.Connectivity.ConnectivityChanged += (sender, args) =>
            {
                IsOffline = !args.IsConnected;
            };
        }
    }
}
