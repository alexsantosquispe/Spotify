using Plugin.Connectivity;

namespace Spotify.Utils
{
    public class Network
    {
        public bool IsConnected()
        {
            return CrossConnectivity.Current.IsConnected;
        }

        public Network() { }
    }
}