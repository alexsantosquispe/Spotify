using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Spotify.Views;
using Spotify.Themes;
using Plugin.FirebasePushNotification;
using Spotify.Utils;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Spotify
{
    public partial class App : Application
    {
        private readonly IStore Store = new Store();

        public App()
        {
            InitializeComponent();
            ThemeManager.LoadTheme();
            if (!Store.Exist("Email"))
            {
                MainPage = new NavigationPage(new LoginPage());
            } else
            {
                MainPage = new NavigationPage(new HomePage());
            }            
        }

        protected override void OnStart()
        {
            CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine($"TOKEN REC: {p.Token}");
            };

            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Received");
            };

            CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Opened");
                foreach (var data in p.Data)
                {
                    System.Diagnostics.Debug.WriteLine($"{data.Key}: {data.Value}");
                }
            };

            CrossFirebasePushNotification.Current.OnNotificationAction += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Action");
                if (!string.IsNullOrEmpty(p.Identifier))
                {
                    System.Diagnostics.Debug.WriteLine($"ActionId: {p.Identifier}");
                    foreach (var data in p.Data)
                    {
                        System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
                    }
                }
            };

            CrossFirebasePushNotification.Current.OnNotificationDeleted += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Deleted");
            };
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
