using netflixRoulette.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace netflixRoulette
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MoviePage : ContentPage
	{
		private HttpClient _client = new HttpClient();
		private int movieId;
		private Movie movie;

		public MoviePage(int movieId)
		{
			this.movieId = movieId;
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			FetchMovie(movieId);
		}

		private async void FetchMovie(int movieId)
		{
			try
			{
				var content = await _client.GetStringAsync($"https://api.themoviedb.org/3/movie/{movieId}?api_key=753434cd814a187484a6ad7f29768fe0&append_to_response=credits");
				movie = JsonConvert.DeserializeObject<Movie>(content);
			}
			catch (HttpRequestException e)
			{
				// Handle error...
			}
			finally
			{
				if (movie != null) RenderMovie(movie);
			}
		}

		private void RenderMovie(Movie movie)
		{
			Title.Text = movie.Title;
			Tagline.Text = movie.Tagline;
			Overview.Text = movie.Overview;
			Backdrop.Source = $"https://image.tmdb.org/t/p/original/{movie.BackdropPath}";
			Poster.Source = $"https://image.tmdb.org/t/p/original/{movie.PosterPath}";
			RenderGenres(movie);
			RenderRuntime(movie);
			Released.Text = movie.ReleaseDate.Year.ToString();
			RenderCast(movie);
		}

		private void RenderGenres(Movie movie)
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

		private void RenderRuntime(Movie movie)
		{
			var minutes = movie.Runtime % 60;
			var hours = (int)movie.Runtime / 60;
			Runtime.Text = $"{hours}h {minutes}m";
		}

		private void RenderCast(Movie movie)
		{
			for (int castIndex = 0; castIndex < Math.Min(movie.Credits.Cast.Length, 5); castIndex++)
			{
				var cast = movie.Credits.Cast[castIndex];
				CastGrid.Children.Add(new Image
				{
					Source = $"https://image.tmdb.org/t/p/w185/{cast.ProfilePath}",
					HeightRequest = 50
				}, 0, castIndex);
				CastGrid.Children.Add(new Label
				{
					Text = cast.Name,
					FontSize = 16,
					VerticalTextAlignment = TextAlignment.Center
				}, 1, castIndex);
				CastGrid.Children.Add(new Label
				{
					Text = cast.Character,
					FontSize = 16,
					VerticalTextAlignment = TextAlignment.Center
				}, 2, castIndex);
			}
		}
	}
}