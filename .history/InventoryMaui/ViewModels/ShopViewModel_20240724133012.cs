using System.Collections.ObjectModel;
using System.Windows.Input;
using InventoryManage; 
using Microsoft.Maui.Controls;

namespace InventoryMaui.ViewModels
{
    public class ShopViewModel : BaseViewModel
    {
        private ShopProxy shopProxy;
        private ItemDTO selectedItem;
      

        public ObservableCollection<ItemDTO> Items { get; set; }
        public ObservableCollection<CartItem> CartItems { get; set; }
        public ItemDTO SelectedItem
        {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value);
        }

        public ICommand AddToCartCommand { get; }
        public ICommand RemoveFromCartCommand { get; }
        public ICommand CheckoutCommand { get; }

        public ShopViewModel()
        {
            shopProxy = ShopProxy.Instance;
            shopProxy.ItemsUpdated += OnItemsUpdated;
            shopProxy.CartUpdated += OnCartUpdated;

            Items = new ObservableCollection<ItemDTO>(shopProxy.GetItems());
            CartItems = new ObservableCollection<CartItem>(shopProxy.GetCartItems());

            AddToCartCommand = new Command<Item>(OnAddToCart);
            RemoveFromCartCommand = new Command<Item>(OnRemoveFromCart);
            CheckoutCommand = new Command(OnCheckout);
            
        }
        public double Subtotal => shopProxy.Subtotal;
        public double Tax => shopProxy.Tax;
        public double Total => shopProxy.Total;
        private void OnAddToCart(Item item)
        {
            if (item != null)
            {
                shopProxy.AddToCart(item.Id, 1); 
                RefreshItems();
                RefreshCartItems();
            }
        }

        private void OnRemoveFromCart(Item item)
        {
            if (item != null)
            {
                shopProxy.RemoveFromCart(item.Id, 1); 
                RefreshItems();
                RefreshCartItems();
            }
        }

        private void OnCheckout()
        {
            shopProxy.Checkout();
            RefreshItems();
            RefreshCartItems();
        }

        private void RefreshItems()
        {
            Items.Clear();
            foreach (var item in shopProxy.GetItems())
            {
                Items.Add(item);
            }
        }

        private void RefreshCartItems()
        {
            CartItems.Clear();
            foreach (var cartItem in shopProxy.GetCartItems())
            {
                CartItems.Add(cartItem);
            }
        }
         private void OnItemsUpdated()
        {
            RefreshItems();
        }

         private void OnItemsChanged()
        {
            RefreshItems();
        }
           private void OnCartUpdated()
        {
            RefreshCartItems();
              OnPropertyChanged(nameof(Subtotal));
              OnPropertyChanged(nameof(Tax));
              OnPropertyChanged(nameof(Total));
           
        }
    }
}