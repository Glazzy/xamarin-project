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
	public partial class RandomMoviePage : ContentPage
	{
		private HttpClient _client = new HttpClient();
		private IList<Movie> randomMovies;

		public RandomMoviePage()
		{
			InitializeComponent();
		}


		private async Task<Movie> getRandomMovie(int genreId)
		{
			var genre = $"&with_genres={genreId}"; 
			var baseUrl = "https://api.themoviedb.org/3";
			Random random = new Random();

			int randomPage = random.Next(0, 500);

			var url = $"{baseUrl}/discover/movie?api_key=753434cd814a187484a6ad7f29768fe0{genre}&page={randomPage}";

			var content = await _client.GetStringAsync(url);

			var dataObj = JsonConvert.DeserializeObject<Example>(content);

			IList<Movie> randomMovies = dataObj.results;

			int index = random.Next(randomMovies.Count);

			var randomMovie = randomMovies[index];

			return randomMovie;
		}

		private async void randomMovie(object sender, EventArgs e)
		{
			string data = ((Button)sender).BindingContext as string;
			Movie movie;

			switch (data)
			{
				case "Action":
					movie = await getRandomMovie(28);
					break;
				case "Comedy":
					 movie = await getRandomMovie(35);
					break;
				case "Drama":
					movie = await getRandomMovie(18);
					break;
				case "Thriller":
					movie = await getRandomMovie(53);
					break;
				case "Family":
					movie = await getRandomMovie(10751);
					break;
				default:
					movie = await getRandomMovie(28);
					break;
			}
			

		}
	}
}