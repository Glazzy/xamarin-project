using Newtonsoft.Json;

namespace netflixRoulette.Models
{
	public class Genre
	{
		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}