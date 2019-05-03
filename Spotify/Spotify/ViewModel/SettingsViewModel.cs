using System.Windows.Input;
using Spotify.Views;
using Xamarin.Forms;

namespace Spotify.ViewModel
{
    public class SettingsViewModel : BaseViewModel
    {
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

        private bool _status;

        public bool Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        public ICommand LogoutCommand { get; private set; }

        private readonly INavigation _navigation;

        public void SetCurrentEmailUser()
        {
            if (Application.Current.Properties.ContainsKey("Email"))
            {
                EmailUser = Application.Current.Properties["Email"].ToString();
            }
        }        

        public async void GoToLoginPage()
        {
            _navigation.InsertPageBefore(new LoginPage(), _navigation.NavigationStack[0]);
            await _navigation.PopToRootAsync();
        }

        public void RemoveSession()
        {
            if (Application.Current.Properties.ContainsKey("Email"))
            {
                EmailUser = "";
                Application.Current.Properties.Remove("Email");
            }
        }

        public void Logout()
        {
            RemoveSession();
            GoToLoginPage();
        }

        public SettingsViewModel(INavigation navigation)
        {
            _navigation = navigation;
            SetCurrentEmailUser();
            LogoutCommand = new Command(Logout);
        }
    }
}
