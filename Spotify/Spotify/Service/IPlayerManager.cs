namespace Spotify.Service
{
    public interface IPlayerManager
    {
        /// <summary>
        /// Plays a song selected from an Url
        /// </summary>
        /// <param name="url"></param>
        void Play(string url);
    }
}
