using netflixRoulette.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace netflixRoulette
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MoviePage : ContentPage
	{
		private int MovieID = 389;
		private HttpClient _client = new HttpClient();

		public MoviePage()
		{
			InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			var content = await _client.GetStringAsync($"https://api.themoviedb.org/3/movie/{MovieID}?api_key=753434cd814a187484a6ad7f29768fe0&append_to_response=credits");
			var movie = JsonConvert.DeserializeObject<Movie>(content);

			Title.Text = movie.Title;
			Tagline.Text = movie.Tagline;
			Overview.Text = movie.Overview;
			Backdrop.Source = $"https://image.tmdb.org/t/p/original/{movie.BackdropPath}";
			Poster.Source = $"https://image.tmdb.org/t/p/original/{movie.PosterPath}";
		}
	}
}