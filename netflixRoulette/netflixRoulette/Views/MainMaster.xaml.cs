using netflixRoulette.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace netflixRoulette
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMaster : ContentPage
	{
		public ListView ListView;

		public MainMaster()
		{
			InitializeComponent();

			BindingContext = new MainMasterViewModel(Navigation);
			ListView = MenuItemsListView;
		}
	}
}