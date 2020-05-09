using Newtonsoft.Json;
using System.Collections.Generic;

namespace netflixRoulette.Models
{
	public class Credits
	{
		[JsonProperty("cast")]
		public Cast[] Cast { get; set; }

		[JsonProperty("crew")]
		public Crew[] Crew { get; set; }
	}
}
