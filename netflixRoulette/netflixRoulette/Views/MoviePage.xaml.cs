using netflixRoulette.Models;
using netflixRoulette.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace netflixRoulette
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MoviePage : ContentPage
	{
		public MovieViewModel ViewModel { get; set; }

		public MoviePage(long movieId)
		{
			ViewModel = new MovieViewModel(movieId);
			BindingContext = ViewModel;
			InitializeComponent();
		}
	}
}