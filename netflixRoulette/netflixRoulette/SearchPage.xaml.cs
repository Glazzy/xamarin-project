using netflixRoulette.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace netflixRoulette
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPage : ContentPage
	{
		public SearchViewModel ViewModel { get; set; }

		public SearchPage()
		{
			ViewModel = new SearchViewModel(Navigation);
			BindingContext = ViewModel;
			InitializeComponent();
		}

		public SearchPage(string query)
		{
			ViewModel = new SearchViewModel(Navigation, query);
			BindingContext = ViewModel;
			InitializeComponent();
		}
	}
}