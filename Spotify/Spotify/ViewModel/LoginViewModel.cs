using System.Threading.Tasks;
using Xamarin.Forms;

namespace Spotify.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public bool EmailError { get; set; }

        public bool PasswordError { get; set; }

        private string _emailText;

        public string EmailText
        {
            get { return _emailText; }
            set { _emailText = value; }
        }

        private string _passwordText;

        public string PasswordText
        {
            get { return _passwordText; }
            set { _passwordText = value; }
        }

        public Command OnLoginCommand { get; private set; }

        public LoginViewModel()
        {
            EmailError = PasswordError = false;
            OnLoginCommand = new Command(() => OnLogin(), () => true);
        }

        public void OnLogin()
        {
            if (_emailText == null && _emailText == "")
            {
                EmailError = true;
            }
            if (_passwordText == null && _passwordText == "")
            {
                PasswordError = true;
            }
        }
    }
}
