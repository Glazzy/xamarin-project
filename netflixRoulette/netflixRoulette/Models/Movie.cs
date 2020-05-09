using Newtonsoft.Json;
using System;

namespace netflixRoulette.Models
{
	public class Movie
	{
		[JsonProperty("adult")]
		public bool Adult { get; set; }

		[JsonProperty("backdrop_path")]
		public string BackdropPath { get; set; }

		public string BackdropPathOriginal
		{
			get => $"https://image.tmdb.org/t/p/original/{BackdropPath}";
		}

		[JsonProperty("belongs_to_collection")]
		public object BelongsToCollection { get; set; }

		[JsonProperty("budget")]
		public long Budget { get; set; }

		[JsonProperty("genres")]
		public Genre[] Genres { get; set; }

		public string GenresText
		{
			get => string.Join<Genre>(", ", Genres);
		}

		[JsonProperty("homepage")]
		public string Homepage { get; set; }

		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("imdb_id")]
		public string ImdbId { get; set; }

		[JsonProperty("original_language")]
		public string OriginalLanguage { get; set; }

		[JsonProperty("original_title")]
		public string OriginalTitle { get; set; }

		[JsonProperty("overview")]
		public string Overview { get; set; }

		[JsonProperty("popularity")]
		public double Popularity { get; set; }

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

		[JsonProperty("production_companies")]
		public ProductionCompany[] ProductionCompanies { get; set; }

		[JsonProperty("production_countries")]
		public ProductionCountry[] ProductionCountries { get; set; }

		[JsonProperty("release_date")]
		public DateTimeOffset ReleaseDate { get; set; }

		[JsonProperty("revenue")]
		public long Revenue { get; set; }

		[JsonProperty("runtime")]
		public long Runtime { get; set; }

		public TimeSpan RuntimeSpan
		{
			get => TimeSpan.FromMinutes(Runtime);
		}

		[JsonProperty("spoken_languages")]
		public SpokenLanguage[] SpokenLanguages { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("tagline")]
		public string Tagline { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("video")]
		public bool Video { get; set; }

		[JsonProperty("vote_average")]
		public double VoteAverage { get; set; }

		[JsonProperty("vote_count")]
		public long VoteCount { get; set; }

		[JsonProperty("credits")]
		public Credits Credits { get; set; }

		public override string ToString()
		{
			return Title;
		}
	}
}
