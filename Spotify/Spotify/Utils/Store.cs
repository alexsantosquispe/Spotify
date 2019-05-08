using Xamarin.Forms;

namespace Spotify.Utils
{
    public class Store : IStore
    {
        public string GetValue(string key)
        {
            string value = "";
            if (Application.Current.Properties.ContainsKey(key))
            {
                value = Application.Current.Properties[key].ToString();
            }
            return value;
        }

        public void RemoveValue(string key)
        {
            if (Application.Current.Properties.ContainsKey(key))
            {
                Application.Current.Properties.Remove(key);
            }
        }

        public void SetValue(string key, string value)
        {
            Application.Current.Properties[key] = value;
        }
    }
}
