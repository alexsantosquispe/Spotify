﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spotify.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spotify.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
		public DetailPage (Artist artist)
		{
			InitializeComponent();
            
            BindingContext = artist;
		}
	}
}