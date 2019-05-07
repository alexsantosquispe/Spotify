using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Spotify.Service
{
    public class FireBaseAuth : IFirebaseAuthService
    {
        private readonly string USER_EMAIL = "alex.santos@jalasoft.com";

        private readonly string PASSWORD = "123456";

        private void _SaveSession(string email)
        {
            Application.Current.Properties["Email"] = email;
        }

        private void _RemoveSession()
        {
            if (Application.Current.Properties.ContainsKey("Email"))
            {
                Application.Current.Properties.Remove("Email");
            }
        }

        public bool SignIn(string email, string password)
        {
            if (email == USER_EMAIL && password == PASSWORD)
            {
                _SaveSession(email);
                return true;
            }
            return false;
        }

        public bool Logout()
        {
            _RemoveSession();
            return true;
        }

        public FireBaseAuth() { }
    }
}
