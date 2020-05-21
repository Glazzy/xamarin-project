using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace netflixRoulette.ViewModels
{
	class MainMasterViewModel : BaseViewModel
	{
		public ObservableCollection<MainMasterMenuItem> MenuItems { get; set; }
		private INavigation navigation;
		private string searchQuery;

		public MainMasterViewModel(INavigation navigation)
		{
			this.navigation = navigation;
			MenuItems = new ObservableCollection<MainMasterMenuItem>(new[]
			{
				new MainMasterMenuItem { Id = 0, Title = "Home", TargetType = typeof(MainDetail) },
				new MainMasterMenuItem { Id = 1, Title = "Favorites", TargetType = typeof(FavoritesPage) },
				new MainMasterMenuItem { Id = 2, Title = "Random Movie", TargetType = typeof(RandomMoviePage) }
			});
		}

		private void DoSearch(object query)
		{
			SearchQuery = string.Empty;
			//navigation.PushAsync(new SearchPage());
			((MasterDetailPage)Application.Current.MainPage).Detail = new NavigationPage(new SearchPage((string)query));
			((MasterDetailPage)Application.Current.MainPage).IsPresented = false;
		}

		public Command SearchCommand
		{
			get => new Command(DoSearch);
		}

		public string SearchQuery
		{
			get => searchQuery;
			set
			{
				searchQuery = value;
				OnPropertyChanged(nameof(SearchQuery));
			}
		}
	}
}
