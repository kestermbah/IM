using InventoryMaui.ViewModels;
namespace InventoryMaui;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
	}

	private void ManageInventoryClicked (object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Inventory");
	}

	private void ShopClicked (object sender, EventArgs e)
	{
				Shell.Current.GoToAsync("//Shop");

	}
}

