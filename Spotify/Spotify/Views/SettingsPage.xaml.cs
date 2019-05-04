using Spotify.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spotify.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = new SettingsViewModel(Navigation);
        }
    }
}