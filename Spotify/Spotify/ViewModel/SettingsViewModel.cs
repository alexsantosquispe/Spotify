﻿using System.Windows.Input;
using Spotify.Views;
using Xamarin.Forms;

namespace Spotify.ViewModel
{
    public class SettingsViewModel : BaseViewModel
    {
        public ICommand LogoutCommand { get; private set; }

        private readonly INavigation _navigation;        

        private string _emailUser;

        public string EmailUser
        {
            get { return _emailUser; }
            set
            {
                _emailUser = value;
                OnPropertyChanged("EmailUser");
            }
        }

        public async void GoToLoginPage()
        {
            _navigation.InsertPageBefore(new LoginPage(), _navigation.NavigationStack[0]);
            await _navigation.PopToRootAsync();
        }

        public void RemoveSession()
        {
            if (Application.Current.Properties.ContainsKey("Email"))
            {
                EmailUser = "";
                Application.Current.Properties.Remove("Email");
            }
        }

        public void Logout()
        {
            RemoveSession();
            SetCurrentTheme();
            GoToLoginPage();
        }

        public SettingsViewModel(INavigation navigation)
        {
            _navigation = navigation;
            EmailUser = GetCurrentEmailUser();
            Theme = GetCurrentTheme();
            LogoutCommand = new Command(Logout);
        }
    }
}
