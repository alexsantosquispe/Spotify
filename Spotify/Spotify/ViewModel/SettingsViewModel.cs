using System.Windows.Input;
using Spotify.Config;
using Spotify.Views;
using Xamarin.Forms;

namespace Spotify.ViewModel
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly IRemoteConfig _remoteConfig = DependencyService.Get<IRemoteConfig>();

        public ICommand LogoutCommand { get; private set; }

        public ICommand GetRemoteConfigCommand { get; private set; }

        private readonly INavigation _navigation;

        private string _emailUser;

        public string EmailUser
        {
            get { return _emailUser; }
            set
            {
                _emailUser = value;
                OnPropertyChanged("EmailUser");
            }
        }

        /// <summary>
        /// Goes to LoginViewPage
        /// </summary>
        public async void GoToLoginPage()
        {
            _navigation.InsertPageBefore(new LoginPage(), _navigation.NavigationStack[0]);
            await _navigation.PopToRootAsync();
        }

        /// <summary>
        /// Closes current session
        /// </summary>
        public void Logout()
        {
            FirebaseAuth.Logout();
        }

        /// <summary>
        /// Closes current session and redirect to login page
        /// </summary>
        public void OnLogout()
        {
            Logout();
            GoToLoginPage();
        }

        /// <summary>
        /// Sets the remote theme
        /// </summary>
        public void GetRemoteTheme()
        {
            string theme = _remoteConfig.GetRemoteData();
            SetCurrentTheme(theme);
        }

        /// <summary>
        /// Initializes properties
        /// </summary>
        /// <param name="navigation"></param>
        public SettingsViewModel(INavigation navigation)
        {
            _navigation = navigation;
            EmailUser = GetCurrentEmailUser();
            Theme = GetCurrentTheme();
            LogoutCommand = new Command(OnLogout);
            GetRemoteConfigCommand = new Command(GetRemoteTheme);
        }
    }
}
