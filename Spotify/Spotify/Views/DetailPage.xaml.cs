using Spotify.Models;
using Spotify.ViewModel;
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
            
            BindingContext = new DetailViewModel(artist);
		}
    }
}