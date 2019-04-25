using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spotify.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            btnLogin.Clicked += _OnLogin;
        }

        private async void _OnLogin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }

        //private void _ValidateEmail()
        //{
        //    if (entryEmail.Text == null || entryEmail.Text == "") 
        //    {
        //        emailError.Text = "This field is required";
        //        emailError.IsVisible = true;
        //        IsValid = false;
        //    }
        //    else
        //    {
        //        emailError.IsVisible = false;
        //        emailError.Text = "";
        //        IsValid = true;
        //    }
        //}

        //private void _ValidatePassword()
        //{
        //    if (entryPassword.Text == null && entryPassword.Text == "")
        //    {
        //        passwordError.Text = "This field is required";
        //        passwordError.IsVisible = true;
        //        IsValid = false;
        //    }
        //    else
        //    {
        //        passwordError.IsVisible = false;
        //        passwordError.Text = "";
        //        IsValid = true;
        //    }
        //}
    }
}
