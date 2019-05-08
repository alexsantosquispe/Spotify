using System;
using Spotify.Utils;

namespace Spotify.Test.Mock
{
    public class MockStore : IStore
    {
        public string defaultValue = "Light";

        public string GetValue(string key)
        {
            return defaultValue;
        }

        public void SetValue(string key, string value)
        {
            defaultValue = value;
        }

        public void RemoveValue(string key)
        {
            defaultValue = null;
        }
    }
}
