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
		private string searchQuery;

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

		private async void FetchMovies(string query, int page = 1)
		{
			Results = await MovieDataAccess.SearchMoviesAsync(query, page);
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

		public string Pages
		{
			get => $"Page {results?.Page} of {results?.TotalPages}";
		}

		public bool NotFirstPage
		{
			get => results?.Page > 1;
		}

		public bool NotLastPage
		{
			get => results?.Page < results?.TotalPages;
		}

		private void PreviousPage(object obj)
		{
			FetchMovies(query, (int)results.Page - 1);
		}

		public Command PreviousCommand
		{
			get => new Command(PreviousPage);
		}

		private void NextPage(object obj)
		{
			FetchMovies(query, (int)results.Page + 1);
		}

		public Command NextCommand
		{
			get => new Command(NextPage);
		}

		private void DoSearch(object query)
		{
			SearchQuery = string.Empty;
			FetchMovies((string)query);
		}

		public Command SearchCommand
		{
			get => new Command(DoSearch);
		}

		public string SearchQuery
		{
			get => searchQuery;
			set
			{
				searchQuery = value;
				OnPropertyChanged(nameof(SearchQuery));
			}
		}

		private void RowTapped(object obj)
		{
			var movie = (MovieResult)obj;
			navigation.PushAsync(new MoviePage(movie.Id));
		}

		public Command TappedCommand
		{
			get => new Command(RowTapped);
		}
	}
}
