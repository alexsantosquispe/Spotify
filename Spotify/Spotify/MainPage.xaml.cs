using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Spotify.Views;

namespace Spotify
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnLogin.Clicked += OnLogin;
        }

        private async void OnLogin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }
    }
}
