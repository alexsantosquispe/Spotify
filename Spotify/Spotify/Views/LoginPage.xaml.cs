using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Spotify.ViewModel;

namespace Spotify.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);
            //btnLogin.Clicked += _OnLogin;
        }

        private async void _OnLogin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }
    }
}
