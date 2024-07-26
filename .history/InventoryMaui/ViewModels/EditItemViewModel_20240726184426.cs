using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using InventoryManage;
namespace InventoryMaui.ViewModels
{
    public class EditItemViewModel : BaseViewModel
    {
        private int _itemId;
        private string _name;
        private string _description;
        private double _price;
        private int _quantity;

        private readonly ItemServiceProxy _itemService;

        public EditItemViewModel()
        {
            _itemService = ItemServiceProxy.Current;
            SaveCommand = new Command(async () => await OnSave());
        }

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

        public double Price
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

        private async Task OnSave()
        {
            var item = new ItemDTO
            {
                Id = ItemId,
                Name = Name,
                Description = Description,
                Price = Price,
                Quantity = Quantity
            };
            _itemService.AddOrUpdate(item);

        
        }

       

        public void LoadItem(int itemId)
        {
            var item = _itemService.GetItemById(itemId);
            if (item != null)
            {
                ItemId = item.Id;
                Name = item.Name;
                Description = item.Description;
                Price = item.Price ?? 0; // Provide a default value if item.Price is null
                Quantity = item.Quantity ?? 0; // Provide a default value if item.Quantity is null
            }
        }
    }
}