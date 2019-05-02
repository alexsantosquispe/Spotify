using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Spotify.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Spotify
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (Current.Properties.ContainsKey("Email"))
            {
                MainPage = new NavigationPage(new HomePage())
                {
                    BarTextColor = Color.Black
                };
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage())
                {
                    BarTextColor = Color.Black
                };
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
