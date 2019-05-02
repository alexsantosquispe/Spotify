using System.ComponentModel;
using System.Runtime.CompilerServices;
using Plugin.Connectivity;
using Spotify.Utils;

namespace Spotify.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _isLoading = false;

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }
        private bool _isOffline = !CrossConnectivity.Current.IsConnected;

        public bool IsOffline
        {
            get { return _isOffline; }
            set
            {
                _isOffline = value;
                OnPropertyChanged("IsOffline");
            }
        }

        public BaseViewModel()
        {
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                IsOffline = !args.IsConnected;
            };
        }
    }
}
