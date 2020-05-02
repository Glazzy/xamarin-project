using Newtonsoft.Json;

namespace netflixRoulette.Models
{
	public class ProductionCountry
	{
		[JsonProperty("iso_3166_1")]
		public string Iso3166_1 { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}