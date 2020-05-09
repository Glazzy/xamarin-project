using System.ComponentModel;

namespace netflixRoulette.ViewModels
{
	// Base class for all ViewModels that exposes a method to invoke a PropertyChanged event
	public abstract class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		// Defaulting to null will update all properties if called without arguments
		protected void OnPropertyChanged(string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
