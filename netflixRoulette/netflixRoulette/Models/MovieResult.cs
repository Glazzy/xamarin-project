using Newtonsoft.Json;
using System;

namespace netflixRoulette.Models
{
	public class MovieResult
	{
		[JsonProperty("popularity")]
		public double Popularity { get; set; }

		[JsonProperty("vote_count")]
		public long VoteCount { get; set; }

		[JsonProperty("video")]
		public bool Video { get; set; }

		[JsonProperty("poster_path")]
		public string PosterPath { get; set; }

		public string PosterUrl92
		{
			get => $"https://image.tmdb.org/t/p/w92/{PosterPath}";
		}

		public string PosterUrl154
		{
			get => $"https://image.tmdb.org/t/p/w154/{PosterPath}";
		}

		public string PosterUrl185
		{
			get => $"https://image.tmdb.org/t/p/w185/{PosterPath}";
		}

		public string PosterUrl342
		{
			get => $"https://image.tmdb.org/t/p/w342/{PosterPath}";
		}

		public string PosterUrl500
		{
			get => $"https://image.tmdb.org/t/p/w500/{PosterPath}";
		}

		public string PosterUrl780
		{
			get => $"https://image.tmdb.org/t/p/w780/{PosterPath}";
		}

		public string PosterUrlOriginal
		{
			get => $"https://image.tmdb.org/t/p/original/{PosterPath}";
		}

		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("adult")]
		public bool Adult { get; set; }

		[JsonProperty("backdrop_path")]
		public string BackdropPath { get; set; }

		[JsonProperty("original_language")]
		public string OriginalLanguage { get; set; }

		[JsonProperty("original_title")]
		public string OriginalTitle { get; set; }

		[JsonProperty("genre_ids")]
		public long[] GenreIds { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("vote_average")]
		public double VoteAverage { get; set; }

		[JsonProperty("overview")]
		public string Overview { get; set; }

		[JsonProperty("release_date")]
		public DateTimeOffset? ReleaseDate { get; set; }
	}
}
