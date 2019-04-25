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
    }
}
