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

		public MoviePage(int movieId)
		{
			ViewModel = new MovieViewModel(movieId);
			BindingContext = ViewModel;
			InitializeComponent();
		}

		public MoviePage(Movie movie)
		{
			ViewModel = new MovieViewModel(movie);
			BindingContext = ViewModel;
			InitializeComponent();
		}
	}
}