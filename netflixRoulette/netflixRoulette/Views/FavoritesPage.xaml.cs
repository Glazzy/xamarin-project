using netflixRoulette.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace netflixRoulette
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FavoritesPage : ContentPage
	{
		public FavoritesViewModel ViewModel { get; set; }

		public FavoritesPage()
		{
			ViewModel = new FavoritesViewModel(Navigation);
			BindingContext = ViewModel;
			InitializeComponent();
		}
	}
}