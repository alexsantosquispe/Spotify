using System.Windows.Input;
using Xamarin.Forms;
using Spotify.Utils;
using Spotify.Views;

namespace Spotify.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private INavigation _navigation;

        private readonly Validator validator = new Validator();

        private bool _loginError = false;

        public bool LoginError
        {
            get { return _loginError; }
            set
            {
                _loginError = value;
                OnPropertyChanged("LoginError");
            }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
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

        public string Logo { get; set; }

        public ICommand OnLoginCommand { get; private set; }

        public bool Validate()
        {
            LoginError = false;
            if (validator.IsEmpty(EmailText))
            {
                ErrorMessage = "The email field is required";
                LoginError = true;
                return !LoginError;
            }
            else if (!validator.isEmailAddress(EmailText))
            {
                ErrorMessage = "Invalid Email";
                LoginError = true;
                return !LoginError;
            }
            else if (validator.IsEmpty(PasswordText))
            {
                ErrorMessage = "The password field is required";
                LoginError = true;
                return !LoginError;
            }
            return !LoginError;
        }        

        public async void GoToHomePage()
        {
            _navigation.InsertPageBefore(new HomePage(), _navigation.NavigationStack[0]);
            await _navigation.PopToRootAsync();
        }

        public void OnLogin()
        {            
            if (Validate())
            {
                if (FirebaseAuth.SignIn(EmailText, PasswordText))
                {
                    GoToHomePage();
                }
                else
                {
                    ErrorMessage = "Invalid email or password";
                    LoginError = true;
                }
            }
        }

        public LoginViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Logo = "spotify_logo_" + GetCurrentTheme().ToLower() + ".png";
            OnLoginCommand = new Command(OnLogin);
        }

        public LoginViewModel()
        {
        }
    }
}
