using InventoryMaui.ViewModels;
namespace InventoryMaui.Views;

public partial class AddItemView : ContentPage
{
	public AddItemView()
	{
		InitializeComponent();
		BindingContext = new AddItemViewModel();
	}
	public void CancelClicked(object sender, EventArgs e){
		Shell.Current.GoToAsync("//Inventory");
	}
}