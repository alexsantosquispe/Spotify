using Android.Media;
using Spotify.Droid;
using Spotify.Service;
using Xamarin.Forms;

[assembly: Dependency(typeof(MediaPlayerService))]
namespace Spotify.Droid
{
    public class MediaPlayerService : IPlayerManager
    {
        public void Play(string url)
        {
            var player = new MediaPlayer();
            player.Prepared += (s, e) =>
            {
                player.Start();
            };
            player.SetDataSource(url);
            player.Prepare();
        }

        public void Pause()
        {

        }
    }
}