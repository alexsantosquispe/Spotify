using Plugin.FirebasePushNotification;
using Spotify.Utils;

namespace Spotify.Service
{
    public class FireBaseAuth : IFirebaseAuthService
    {
        private readonly IStore Store = new Store();

        private readonly string USER_EMAIL = "alex.santos@jalasoft.com";

        private readonly string PASSWORD = "123456";

        private void _SaveSession(string email)
        {
            Store.SetValue("Email", email);
        }

        private void _RemoveSession()
        {            
            Store.RemoveValue("Email");
        }

        public bool SignIn(string email, string password)
        {
            if (email == USER_EMAIL && password == PASSWORD)
            {
                _SaveSession(email);
                // Handle when your app starts
                CrossFirebasePushNotification.Current.Subscribe("General");
                return true;
            }
            return false;
        }

        public bool Logout()
        {
            _RemoveSession();
            CrossFirebasePushNotification.Current.UnsubscribeAll();
            return true;
        }

        public FireBaseAuth() { }
    }
}
