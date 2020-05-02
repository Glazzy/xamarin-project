using Newtonsoft.Json;

namespace netflixRoulette.Models
{
	public class SpokenLanguage
	{
		[JsonProperty("iso_639_1")]
		public string Iso639_1 { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}