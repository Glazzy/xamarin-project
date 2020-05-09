using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Web;
using System.Threading.Tasks;
using netflixRoulette.Models;

namespace netflixRoulette
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainDetail : ContentPage
	{
		private HttpClient _client = new HttpClient();
        private IList<Result> discoverMovies;

        public MainDetail()
		{
            InitializeComponent();
        }


		protected override async void OnAppearing()
		{
            discoverMovies = await FetchDiscoverMovies();

            CreateDiscoverGrid(discoverMovies);

            base.OnAppearing();
		}

        private async Task<IList<Result>> FetchDiscoverMovies()
        {
            var content = await _client.GetStringAsync("https://api.themoviedb.org/3/discover/movie?api_key=753434cd814a187484a6ad7f29768fe0");
            var dataObj = JsonConvert.DeserializeObject<Example>(content);

            return dataObj.results;
        }

        private void CreateDiscoverGrid(IList<Result> discoverMovies)
        {
            gridLayout.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            var movieIndex = 0;

            for (int rowIndex = 0; rowIndex < discoverMovies.Count; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                {
                    if (movieIndex >= discoverMovies.Count)
                    {
                        break;
                    }
                    var movie = discoverMovies[movieIndex];
                    movieIndex += 1;

                    Image image = new Image();
                    image.Source = "https://image.tmdb.org/t/p/w500/" + movie.poster_path;

                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += async (s, e) =>
                    {
                        var tabbedMovieId = movie.id;
                        await Navigation.PushAsync(new MoviePage(tabbedMovieId));
                    };

                    image.GestureRecognizers.Add(tapGestureRecognizer);
                    gridLayout.Children.Add(image, columnIndex, rowIndex);
                }
            }
        }

    }
}