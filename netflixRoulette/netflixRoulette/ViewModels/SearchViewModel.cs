using netflixRoulette.DataAccess;
using netflixRoulette.Models;
using Xamarin.Forms;

namespace netflixRoulette.ViewModels
{
	public class SearchViewModel : BaseViewModel
	{
		private INavigation navigation;
		private string query;
		private Results results;

		public SearchViewModel(INavigation navigation)
		{
			this.navigation = navigation;
		}

		public SearchViewModel(INavigation navigation, string query)
		{
			this.navigation = navigation;
			this.query = query;
			FetchMovies(query);
		}

		private async void FetchMovies(string query)
		{
			Results = await MovieDataAccess.SearchMoviesAsync(query);
		}

		public Results Results
		{
			get => results;
			set
			{
				results = value;
				OnPropertyChanged();
			}
		}
	}
}
