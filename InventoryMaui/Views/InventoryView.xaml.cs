using InventoryMaui.ViewModels;
namespace InventoryMaui.Views;

public partial class InventoryView : ContentPage
{
	public InventoryView()
	{
		InitializeComponent();
		BindingContext = new InventoryViewModel();
	}
	public void GoBackClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}
	public void addItemClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//AddItem");
	}
	public void deleteItemClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//DeleteItem");
	}
}