using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Web;
using System.Globalization;

namespace netflixRoulette
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainDetail : ContentPage
	{
		private const string Url = "https://api.themoviedb.org/discover/movie";
		private HttpClient _client = new HttpClient();
        private List<Result> movieArrayList;
        public Uri getUrl()
        {
            var builder = new UriBuilder("https://api.themoviedb.org/discover/movie");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["apiKey"] = "753434cd814a187484a6ad7f29768fe0";
            builder.Query = query.ToString();
            var url = new Uri(builder.ToString());
            return url;
        }

		public MainDetail()
		{
			InitializeComponent();

        }


		protected override async void OnAppearing()
		{
			var content = await _client.GetStringAsync("https://api.themoviedb.org/3/discover/movie?api_key=753434cd814a187484a6ad7f29768fe0");
            var discoverObj = JsonConvert.DeserializeObject<Example>(content);


            movieArrayList = new List<Result>(discoverObj.results);

            gridLayout.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1 , GridUnitType.Star)});
            gridLayout.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            gridLayout.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star)});
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });




            var movieIndex = 0;

            for (int rowIndex = 0; rowIndex < movieArrayList.Count; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                {
                    if (movieIndex >= movieArrayList.Count)
                    {
                        break;
                    }
                    var movie = movieArrayList[movieIndex];
                    movieIndex += 1;

                    Image image = new Image();
                    image.Source = "https://image.tmdb.org/t/p/w500/" + movie.poster_path;
                 
   

                    gridLayout.Children.Add(image, columnIndex, rowIndex);
                }
            }


            base.OnAppearing();
		}
	}

    public class Result
    {
        public double popularity { get; set; }
        public int vote_count { get; set; }
        public bool video { get; set; }
        public string poster_path { get; set; }
        public int id { get; set; }
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public IList<int> genre_ids { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
    }

    public class Example
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public IList<Result> results { get; set; }
    }


}