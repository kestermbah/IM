using InventoryMaui.ViewModels;
namespace InventoryMaui.Views;

public partial class DeleteItemView : ContentPage
{
	public DeleteItemView()
	{
		InitializeComponent();
		BindingContext = new DeleteItemViewModel();
	}
	public void CancelClicked(object sender, EventArgs e){
		Shell.Current.GoToAsync("//Inventory");
	}
}