using System;
using Spotify.Models;
using Spotify.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spotify.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        const string SEARCH = "/search?";

        public HomePage ()
		{
			InitializeComponent ();
            artistList.ItemSelected += _ShowDetail;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ShowLoader();
            _PopulateArtists();
        }

        private void _ShowLoader()
        {
            loader.IsEnabled = true;
            loader.IsRunning = true;
            loader.IsVisible = true;
        }

        private void _HideLoader()
        {
            loader.IsEnabled = false;
            loader.IsRunning = false;
            loader.IsVisible = false;
        }

        private async void _SearchArtist()
        {
            try
            {
                SpotifyAPI clientSpotify = new SpotifyAPI();
                var ObjectResult = await clientSpotify.GetArtists<ArtistResult>("https://api.spotify.com/v1/search?q=rock&type=artist&limit=20&offset=0");
                if (ObjectResult != null)
                {
                    Artists artists = ObjectResult.artists;
                    artistList.ItemsSource = artists.Items;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("=> POPULATE ARTIST <=");
                Console.WriteLine(e.Message);
            }
            _HideLoader();
        }

        private async void _PopulateArtists()
        {
            try
            {
                SpotifyAPI clientSpotify = new SpotifyAPI();
                var ObjectResult = await clientSpotify.GetArtists<ArtistResult>("https://api.spotify.com/v1/search?q=rock&type=artist&limit=20&offset=0");
                if (ObjectResult != null)
                {
                    Artists artists = ObjectResult.artists;
                    artistList.ItemsSource = artists.Items;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("=> POPULATE ARTIST <=");
                Console.WriteLine(e.Message);
            }
            _HideLoader();
        }

        private async void _ShowDetail(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailPage());
        }
    }
}