using InventoryManage;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace InventoryMaui.ViewModels;

public class AddItemViewModel : INotifyPropertyChanged
{
        private string name;
        private string description;
        private double price;
        private int quantity;   
          public AddItemViewModel()
        {
            Items = new ObservableCollection<ItemDTO>(ItemServiceProxy.Current.Items);
            AddItemCommand = new Command(AddItem);
        }

          public ObservableCollection<ItemDTO> Items { get; }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        public double Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddItemCommand { get; }
        private void AddItem()
        {
            var item = new ItemDTO
            {
                Name = Name,
                Description = Description,
                Price = Price,
                Quantity = Quantity
            };

            var addedItem = ItemServiceProxy.Current.AddorUpdate(item);
            if (addedItem != null)
            {
                Items.Add(addedItem);
            }

           
            Name = string.Empty;
            Description = string.Empty;
            Price = 0;
            Quantity = 0;
        }
          public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
}

    

