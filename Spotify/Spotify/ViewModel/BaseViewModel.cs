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
        public readonly IFirebaseAuthService FirebaseAuth = new FireBaseAuth();
        public readonly IApiService SpotifyAPI = new SpotifyAPI();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string GetCurrentTheme()
        {
            string theme = "";
            if (Application.Current.Properties.ContainsKey("Theme"))
            {
                theme = Application.Current.Properties["Theme"].ToString();
            }
            return theme;
        }

        public void SetCurrentTheme()
        {
            if (Theme == "Dark")
            {
                ThemeManager.ChangeTheme("Light");
                Theme = "Light";
            }            
        }

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

        private bool _isOffline = !Network.Instance.IsConnected;

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

        public BaseViewModel()
        {
            Network.Instance.ConnectivityChanged += (sender, args) =>
            {
                IsOffline = !args.IsConnected;
            };
        }
    }
}
