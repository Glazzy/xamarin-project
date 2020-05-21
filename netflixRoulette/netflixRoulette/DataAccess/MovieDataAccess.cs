using netflixRoulette.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace netflixRoulette.DataAccess
{
	public class MovieDataAccess
	{
		private static readonly HttpClient client = new HttpClient();
		private static readonly string baseUrl = "https://api.themoviedb.org/3";
		private static readonly string apiKey = "753434cd814a187484a6ad7f29768fe0";

		public static async Task<Movie> GetMovieAsync(long movieId, bool withCredits = false)
		{
			var url = $"{baseUrl}/movie/{movieId}?api_key={apiKey}";
			if (withCredits) url += "&append_to_response=credits";
			var content = await client.GetStringAsync(url);
			return JsonConvert.DeserializeObject<Movie>(content);
		}

		public static async Task<Results> SearchMoviesAsync(string query)
		{
			var url = $"{baseUrl}/search/movie?api_key={apiKey}&query={query}";
			var content = await client.GetStringAsync(url);
			return JsonConvert.DeserializeObject<Results>(content);
		}
	}
}
