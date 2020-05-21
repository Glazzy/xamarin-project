using Newtonsoft.Json;

namespace netflixRoulette.Models
{
	public class Results
	{
		[JsonProperty("page")]
		public long Page { get; set; }

		[JsonProperty("total_results")]
		public long TotalResults { get; set; }

		[JsonProperty("total_pages")]
		public long TotalPages { get; set; }

		[JsonProperty("results")]
		public MovieResult[] MovieResults { get; set; }
	}
}
