using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Spotify.Views;
using Spotify.Themes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Spotify
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ThemeManager.LoadTheme();
            if (Current.Properties.ContainsKey("Email"))
            {
                MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
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
