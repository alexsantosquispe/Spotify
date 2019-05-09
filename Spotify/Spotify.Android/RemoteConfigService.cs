using System;
using Android.Widget;
using Firebase.RemoteConfig;
using Spotify.Config;
using Spotify.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(RemoteConfigService))]
namespace Spotify.Droid
{
    public class RemoteConfigService : IRemoteConfig
    {
        private static readonly string DEFAULT_THEME = "default_theme";
        public static FirebaseRemoteConfig firebaseRemoteConfig;
        public string data = "";

        private void InitRemoteConfig()
        {
            firebaseRemoteConfig = FirebaseRemoteConfig.Instance;
            FirebaseRemoteConfigSettings configSettings = new FirebaseRemoteConfigSettings.Builder()
                .SetDeveloperModeEnabled(true)
                .Build();
            firebaseRemoteConfig.SetConfigSettings(configSettings);
            firebaseRemoteConfig.SetDefaults(Resource.Xml.remote_config_defaults);
        }

        private void GetRemoteConfig()
        {
            try
            {
                firebaseRemoteConfig.Fetch(0);
                firebaseRemoteConfig.ActivateFetched();
                data = firebaseRemoteConfig.GetString(DEFAULT_THEME);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR REMOTE CONFIG: " + e.Message);
            }
        }

        public string GetRemoteData()
        {
            InitRemoteConfig();
            GetRemoteConfig();
            return data;
        }
    }
}