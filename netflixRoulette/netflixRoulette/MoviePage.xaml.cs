using netflixRoulette.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace netflixRoulette
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MoviePage : ContentPage
	{
		private HttpClient _client = new HttpClient();
		private Movie movie;

		public MoviePage()
		{
			InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			movie = await fetchMovie(120);
			renderMovie(movie);
		}

		public async void setMovie(int movieId)
		{
			await fetchMovie(movieId);
		}

		private async Task<Movie> fetchMovie(int movieId)
		{
			var content = await _client.GetStringAsync($"https://api.themoviedb.org/3/movie/{movieId}?api_key=753434cd814a187484a6ad7f29768fe0&append_to_response=credits");
			return JsonConvert.DeserializeObject<Movie>(content);
		}

		private void renderMovie(Movie movie)
		{
			Title.Text = movie.Title;
			Tagline.Text = movie.Tagline;
			Overview.Text = movie.Overview;
			Backdrop.Source = $"https://image.tmdb.org/t/p/original/{movie.BackdropPath}";
			Poster.Source = $"https://image.tmdb.org/t/p/original/{movie.PosterPath}";
			renderGenres(movie);
			renderRuntime(movie);
			Released.Text = movie.ReleaseDate.Year.ToString();
			renderCast(movie);
		}

		private void renderGenres(Movie movie)
		{
			var genres = "";
			for (int i = 0; i < movie.Genres.Length; i++)
			{
				genres += movie.Genres[i].Name;
				if (i < movie.Genres.Length - 1)
				{
					genres += ", ";
				}
				else
				{
					Genre.Text = genres;
				}
			}
		}

		private void renderRuntime(Movie movie)
		{
			var minutes = movie.Runtime % 60;
			var hours = (int)movie.Runtime / 60;
			Runtime.Text = $"{hours}h {minutes}m";
		}

		private void renderCast(Movie movie)
		{
			// Not implemented
		}
	}
}