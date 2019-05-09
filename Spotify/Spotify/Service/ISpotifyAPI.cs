using System.Collections.Generic;
using System.Threading.Tasks;
using Spotify.Models;

namespace Spotify.Service
{
    public interface ISpotifyAPI
    {
        /// <summary>
        /// Gets the 20 first occurrences of artist searched
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        Task<List<Artist>> GetArtists(string word);

        /// <summary>
        /// Gets the tops track of an artist selected
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<Track>> GetTopTracks(string id);
    }
}
