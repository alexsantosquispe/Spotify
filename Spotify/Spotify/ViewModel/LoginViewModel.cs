using System.Windows.Input;
using Xamarin.Forms;
using Spotify.Utils;
using Spotify.Views;

namespace Spotify.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private INavigation _navigation;

        private IStore Store = new Store();

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

        public ICommand OnLoginCommand { get; private set; }

        /// <summary>
        /// Validates the email and password fields
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            LoginError = false;
            if (Validator.IsEmpty(EmailText))
            {
                ErrorMessage = "The email field is required";
                LoginError = true;
                return !LoginError;
            }
            else if (!Validator.isEmailAddress(EmailText))
            {
                ErrorMessage = "Invalid Email";
                LoginError = true;
                return !LoginError;
            }
            else if (Validator.IsEmpty(PasswordText))
            {
                ErrorMessage = "The password field is required";
                LoginError = true;
                return !LoginError;
            }
            return !LoginError;
        }        

        /// <summary>
        /// Goes to HomeViewPage
        /// </summary>
        public async void GoToHomePage()
        {
            _navigation.InsertPageBefore(new HomePage(), _navigation.NavigationStack[0]);
            await _navigation.PopToRootAsync();
        }

        /// <summary>
        /// Calls to Fiorebase's login interface and signin
        /// </summary>
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

        /// <summary>
        /// Constructor for LoginViewModel Class
        /// </summary>
        /// <param name="navigation"></param>
        public LoginViewModel(INavigation navigation)
        {
            _navigation = navigation;
            OnLoginCommand = new Command(OnLogin);
        }
    }
}
