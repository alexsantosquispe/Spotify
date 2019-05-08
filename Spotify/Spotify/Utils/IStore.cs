using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Utils
{
    public interface IStore
    {
        /// <summary>
        /// Gets the value of some key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetValue(string key);

        /// <summary>
        /// Sets o creates a new item(key, value)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetValue(string key, string value);

        /// <summary>
        /// Removes item related to key entered
        /// </summary>
        /// <param name="key"></param>
        void RemoveValue(string key);
    }
}
