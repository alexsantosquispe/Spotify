using System;
using Spotify.Config;
using Spotify.iOS;
using Xamarin.Forms;
using Firebase.RemoteConfig;
using Foundation;

[assembly: Dependency(typeof(RemoteConfigService))]
namespace Spotify.iOS
{
    public class RemoteConfigService : IRemoteConfig
    {
        private static readonly string DEFAULT_THEME = "default_theme";
        public string data = "";

        void InitRemoteConfig()
        {
            // Use Firebase library to configure APIs
            //App.Configure();
            // Enabling developer mode, allows for frequent refreshes of the cache
            RemoteConfig.SharedInstance.ConfigSettings = new RemoteConfigSettings(true);
            // You can set default parameter values using an NSDictionary object or a plist file.
            var defaultPlist = NSBundle.MainBundle.PathForResource("ConfigDefaults", "plist");
            if (defaultPlist != null)
            {
                RemoteConfig.SharedInstance.SetDefaults("ConfigDefaults");
            }
        }

        void GetRemoteConfig()
        {
            RemoteConfig.SharedInstance.Fetch(0, (status, error) => {
                switch (status)
                {
                    case RemoteConfigFetchStatus.Success:
                        RemoteConfig.SharedInstance.ActivateFetched();
                        data = RemoteConfig.SharedInstance[DEFAULT_THEME].StringValue;
                        break;
                    case RemoteConfigFetchStatus.Throttled:
                    case RemoteConfigFetchStatus.NoFetchYet:
                    case RemoteConfigFetchStatus.Failure:
                        Console.WriteLine("ERROR FETCHING REMOTE CONFIG");
                        break;
                }
            });
        }

        public string GetRemoteData()
        {
            InitRemoteConfig();
            GetRemoteConfig();
            return data;
        }
    }
}