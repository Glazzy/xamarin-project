using Newtonsoft.Json;
namespace netflixRoulette.Models
{
	public class Cast
	{
		[JsonProperty("cast_id")]
		public long CastId { get; set; }

		[JsonProperty("character")]
		public string Character { get; set; }

		[JsonProperty("credit_id")]
		public string CreditId { get; set; }

		[JsonProperty("gender")]
		public long Gender { get; set; }

		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("order")]
		public long Order { get; set; }

		[JsonProperty("profile_path")]
		public string ProfilePath { get; set; }

		public string ProfileUrlSmall
		{
			get => $"https://image.tmdb.org/t/p/w45/{ProfilePath}";
		}

		public string ProfileUrlMedium
		{
			get => $"https://image.tmdb.org/t/p/w185/{ProfilePath}";
		}

		public string ProfileUrlLarge
		{
			get => $"https://image.tmdb.org/t/p/h632/{ProfilePath}";
		}

		public string ProfileUrlOriginal
		{
			get => $"https://image.tmdb.org/t/p/original/{ProfilePath}";
		}
	}
}