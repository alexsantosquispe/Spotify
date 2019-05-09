using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;

namespace Spotify.Utils
{
    public static class Network
    {
        static IConnectivity connectivity;
        public static IConnectivity Connectivity
        {
            get
            {
                return connectivity ?? (connectivity = CrossConnectivity.Current);
            }
            set
            {
                connectivity = value;
            }
        }        
    }
}