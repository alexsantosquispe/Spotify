using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Service
{
    public interface IFirebaseAuth
    {
        /// <summary>
        /// Passes the respective credentials and makes login 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool SignIn(string email, string password);

        /// <summary>
        /// Closes the current session
        /// </summary>
        /// <returns></returns>
        bool Logout();
    }
}
