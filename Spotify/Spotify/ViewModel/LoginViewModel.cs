using System.Windows.Input;
using Xamarin.Forms;
using Spotify.Utils;
using Spotify.Views;

namespace Spotify.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly string USER_EMAIL = "alex.santos@jalasoft.com";

        private readonly string PASSWORD = "123456";

        private INavigation _navigation;

        private readonly Validator validator = new Validator();

        private bool _emailError = false;

        public bool EmailError
        {
            get { return _emailError; }
            set
            {
                _emailError = value;
                OnPropertyChanged("EmailError");
            }
        }

        private bool _passwordError = false;

        public bool PasswordError
        {
            get { return _passwordError; }
            set
            {
                _passwordError = value;
                OnPropertyChanged("PasswordError");
            }
        }

        private string _emailErrorMessage;

        public string EmailErrorMessage
        {
            get { return _emailErrorMessage; }
            set
            {
                _emailErrorMessage = value;
                OnPropertyChanged("EmailErrorMessage");
            }
        }

        private string _passwordErrorMessage;

        public string PasswordErrorMessage
        {
            get { return _passwordErrorMessage; }
            set
            {
                _passwordErrorMessage = value;
                OnPropertyChanged("PasswordErrorMessage");
            }
        }

        private string _emailText;

        public string EmailText
        {
            get { return _emailText; }
            set
            {
                _emailText = value;
                OnPropertyChanged("EmailText");
            }
        }

        private string _passwordText;

        public string PasswordText
        {
            get { return _passwordText; }
            set
            {
                _passwordText = value;
                OnPropertyChanged("PasswordText");
            }
        }

        private string _logo;

        public string Logo
        {
            get { return _logo; }
            set { _logo = value; }
        }
        public ICommand OnLoginCommand { get; private set; }

        public void ValidateEmail()
        {
            EmailError = false;
            if (validator.IsEmpty(EmailText))
            {
                EmailErrorMessage = "This field is required";
                EmailError = true;
            }
            else if (!validator.isEmailAddress(EmailText) || USER_EMAIL != EmailText)
            {
                EmailErrorMessage = "Invalid Email";
                EmailError = true;
            }
        }

        public void ValidatePassword()
        {
            PasswordError = false;
            if (validator.IsEmpty(PasswordText))
            {
                PasswordErrorMessage = "This field is required";
                PasswordError = true;
            }
            else if (PASSWORD != PasswordText)
            {
                PasswordErrorMessage = "Invalid Password";
                PasswordError = true;
            }
        }

        public async void GoToHomePage()
        {
            _navigation.InsertPageBefore(new HomePage(), _navigation.NavigationStack[0]);
            await _navigation.PopToRootAsync();
        }

        public void SaveSession()
        {
            Application.Current.Properties["Email"] = _emailText;
        }

        public void OnLogin()
        {
            ValidateEmail();
            ValidatePassword();
            if (!EmailError && !PasswordError)
            {
                SaveSession();
                GoToHomePage();
            }
        }

        public LoginViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Logo = "spotify_logo_" + GetCurrentTheme().ToLower() + ".png";
            OnLoginCommand = new Command(OnLogin);
        }
    }
}
