using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Connectivity;

namespace Spotify.Utils
{
    public class Network
    {
        public static bool IsConnected()
        {
            return CrossConnectivity.Current.IsConnected;
        }
    }
}