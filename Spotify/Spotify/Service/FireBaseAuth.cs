using Plugin.FirebasePushNotification;
using Spotify.Utils;

namespace Spotify.Service
{
    public class FireBaseAuth : IFirebaseAuth
    {
        private readonly IStore Store = new Store();

        private readonly string USER_EMAIL = "alex.santos@jalasoft.com";

        private readonly string PASSWORD = "123456";

        /// <summary>
        /// Saves the current session's email 
        /// </summary>
        /// <param name="email"></param>
        private void _SaveSession(string email)
        {
            Store.SetValue("Email", email);
        }

        /// <summary>
        /// Removes previous session saved
        /// </summary>
        private void _RemoveSession()
        {            
            Store.RemoveValue("Email");
        }

        /// <summary>
        /// Checks credentials and login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>bool status to confirm loggin success</returns>
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

        /// <summary>
        /// Logs out current session opened
        /// </summary>
        /// <returns></returns>
        public bool Logout()
        {
            _RemoveSession();
            CrossFirebasePushNotification.Current.UnsubscribeAll();
            return true;
        }

        public FireBaseAuth() { }
    }
}
