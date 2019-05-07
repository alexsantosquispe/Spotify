using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Service
{
    public interface IFirebaseAuthService
    {
        bool SignIn(string email, string password);

        bool Logout();
    }
}
