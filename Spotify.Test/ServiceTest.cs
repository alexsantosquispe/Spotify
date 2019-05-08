using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spotify.Service;
using Spotify.Test.Mock;

namespace Spotify.Test
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public async System.Threading.Tasks.Task GetArtistsTest()
        {
            IApiService SpotifyAPI = new MockServiceAPI();
            var artists = await SpotifyAPI.GetArtists("");
            int max = artists.Count();
            Assert.IsTrue(max == 20);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task GetTracksTest()
        {
            IApiService SpotifyAPI = new MockServiceAPI();
            var tracks = await SpotifyAPI.GetTopTracks("");
            int max = tracks.Count();
            Assert.IsTrue(max == 10);
        }
    }
}
