using System.Collections.Generic;
using System.Threading.Tasks;
using Spotify.Models;
using Spotify.Service;

namespace Spotify.Test.Mock
{
    public class MockServiceAPI : ISpotifyAPI
    {
        public async Task<List<Artist>> GetArtists(string word)
        {
            int max = 20;
            List<Artist> artists = new List<Artist>();
            for (int i = 1; i <= max; i++)
            {
                artists.Add(new Artist()
                {
                    Id = i.ToString(),
                    Name = "artist-" + i.ToString()
                });
            }
            return artists;
        }

        public async Task<List<Track>> GetTopTracks(string id)
        {
            int max = 10;
            List<Track> tracks = new List<Track>();
            for (int i = 1; i <= max; i++)
            {
                tracks.Add(new Track()
                {
                    Id = i.ToString(),
                    Name = "track-" + i.ToString()
                });
            }
            return tracks;
        }
    }
}
