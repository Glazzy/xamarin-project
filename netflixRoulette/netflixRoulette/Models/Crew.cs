using Newtonsoft.Json;
namespace netflixRoulette.Models
{
	public class Crew
	{
		[JsonProperty("credit_id")]
		public string CreditId { get; set; }

		[JsonProperty("department")]
		public string Department { get; set; }

		[JsonProperty("gender")]
		public long Gender { get; set; }

		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("job")]
		public string Job { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("profile_path")]
		public string ProfilePath { get; set; }

	}
}