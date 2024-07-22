namespace InventoryManagement;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	public void ManageInventoryClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Inventory");

	}
	public void ShopClicked(object sender, EventArgs e)
	{
				Shell.Current.GoToAsync("//Shop");
	}
}

