using netflixRoulette.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace netflixRoulette.ViewModels
{
	public class FavoritesViewModel : BaseViewModel
	{
		private readonly int[] favIds = new int[] { 120, 11, 389, 13363, 9693, 17431, 141, 680, 489, 14, 278, 101, 275 };
		private readonly IList<Movie> movies = new ObservableCollection<Movie>();
		private INavigation navigation;

		public FavoritesViewModel(INavigation navigation)
		{
			this.navigation = navigation;
			FetchMovies();
		}

		private async void FetchMovies()
		{
			foreach (var id in favIds)
			{
				Movie movie = await DataAccess.MovieDataAccess.GetMovieAsync(id);
				movies.Add(movie);
			}
		}

		private void RowTapped(object obj)
		{
			var movie = (Movie)obj;
			navigation.PushAsync(new MoviePage(movie));
		}

		public IList<Movie> Movies
		{
			get => movies;
		}

		public Command TappedCommand
		{
			get => new Command(RowTapped);
		}
	}
}
