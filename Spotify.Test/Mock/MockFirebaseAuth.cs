using Spotify.Service;

namespace Spotify.Test.Mock
{
    public class MockFirebaseAuth : IFirebaseAuth
    {
        private readonly string USER_EMAIL = "alex.santos@jalasoft.com";

        private readonly string PASSWORD = "123456";

        public bool Logout()
        {
            return true;
        }

        public bool SignIn(string email, string password)
        {
            if (email == USER_EMAIL && password == PASSWORD)
            {
                return true;
            }
            return false;
        }
    }
}
