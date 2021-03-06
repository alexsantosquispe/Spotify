﻿using System;
using Spotify.Models;
using Spotify.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spotify.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel(Navigation);
            ArtistList.ItemSelected += ArtistSelected;
        }        

        private void ArtistSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Artist artist = (Artist)e.SelectedItem;
                Navigation.PushAsync(new DetailPage(artist));
                ((ListView)sender).SelectedItem = null;
            }
        }       
    }
}