using InventoryMaui.ViewModels;

namespace InventoryMaui.Views
{
    public partial class EditItemPage : ContentPage
    {
        public EditItemPage()
        {
            InitializeComponent();
            BindingContext = new EditItemViewModel();
        }

       
    }
}