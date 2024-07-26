using System.Windows.Input;

namespace InventoryMaui.ViewModels
{
    public class EditItemViewModel : BaseViewModel
    {
        private int _itemId;
        private string _name;
        private string _description;
        private decimal _price;
        private int _quantity;

        public int ItemId
        {
            get => _itemId;
            set => SetProperty(ref _itemId, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public decimal Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        public int Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        public ICommand SaveCommand { get; }

        public EditItemViewModel()
        {
            SaveCommand = new Command(OnSave);
        }

        private async void OnSave()
        {
            // Save the edited item
            await Shell.Current.GoToAsync("..");
        }

        public void LoadItem(int itemId)
        {
            // Load the item based on itemId
            var item = /* fetch the item using itemId */;
            ItemId = item.Id;
            Name = item.Name;
            Description = item.Description;
            Price = item.Price;
            Quantity = item.Quantity;
        }
    }
}