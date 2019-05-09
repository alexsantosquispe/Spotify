using System;
using Spotify.Config;
using Spotify.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(RemoteConfigService))]
namespace Spotify.iOS
{
    public class RemoteConfigService : IRemoteConfig
    {
        public string GetRemoteData()
        {
            string theme = "Light";
            return theme;
        }
    }
}