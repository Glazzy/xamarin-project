using netflixRoulette.Models;
using System.Linq;

namespace netflixRoulette.ViewModels
{
	public class MovieViewModel : BaseViewModel
	{
		private Movie movie;

		public MovieViewModel(long movieId)
		{
			FetchMovie(movieId);
		}

		public MovieViewModel(Movie movie)
		{
			Movie = movie;
		}

		private async void FetchMovie(long movieId)
		{
			Movie = await DataAccess.Movies.GetMovieAsync(movieId, withCredits: true);
		}

		public Movie Movie
		{
			get => movie;
			set
			{
				movie = value;
				OnPropertyChanged();
			}
		}

		// A list with only the first five cast members for the movie page
		public Cast[] CastPreview
		{
			get => Movie?.Credits?.Cast.Take(5).ToArray();
		}
	}
}
