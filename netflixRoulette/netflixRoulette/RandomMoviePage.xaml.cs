using netflixRoulette.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
		private Movie movie;

		public Movie Movie
		{
			get => movie;
			set
			{
				movie = value;
				OnPropertyChanged();
			}
		}

		public RandomMoviePage()
		{
			InitializeComponent();
			BindingContext = this;
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
			

			switch (data)
			{
				case "Action":
					Movie = await getRandomMovie(28);
					break;
				case "Comedy":
					Movie = await getRandomMovie(35);
					break;
				case "Drama":
					Movie = await getRandomMovie(18);
					break;
				case "Thriller":
					Movie = await getRandomMovie(53);
					break;
				case "Family":
					Movie = await getRandomMovie(10751);
					break;
				default:
					Movie = await getRandomMovie(28);
					break;
			}
			

		}
	}
}