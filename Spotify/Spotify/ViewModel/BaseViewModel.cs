using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Spotify.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel() { }

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
    }
}
