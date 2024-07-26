using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using InventoryManage.Models;
﻿namespace InventoryManage
{
    public class ShopProxy
    {
        public double TaxRate = 0.08;
        public double Subtotal => GetCartItems().Sum(item => item.TotalPrice);
        public double Tax => Subtotal * TaxRate;
        public double Total => Subtotal + Tax;

        private static ShopProxy instance;
        private static readonly object lockObj = new object();
        private Shop shop;
        public event Action ItemsUpdated;
        public event Action CartUpdated;

        private ShopProxy(Shop shop)
        {
            this.shop = shop;
            this.shop.ItemsUpdated += OnItemsUpdated;
            this.shop.CartUpdated += OnCartUpdated;
        }

        public static ShopProxy Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            var itemServiceProxy = ItemServiceProxy.Current;
                            var shop = new Shop(itemServiceProxy);
                            instance = new ShopProxy(shop);
                        }
                    }
                }
                return instance;
            }
        }

        public IEnumerable<ItemDTO> GetItems() => shop.GetItems();

        public void AddOrUpdate(ItemDTO item) => shop.AddOrUpdate(item);

        //public void Delete(ItemDTO item) => shop.Delete(item);

        public void AddToCart(int id, int quantity) => shop.AddToCart(id, quantity);

        public void RemoveFromCart(int id, int quantity) => shop.RemoveFromCart(id, quantity);

        public void Checkout() => shop.Checkout();

        public IEnumerable<CartItem> GetCartItems()
        {
            var items = new List<CartItem>();
            foreach (var entry in shop.Cart)
            {
                var item = shop.GetItems().FirstOrDefault(i => i.Id == entry.Key);
                if (item != null)
                {
                    items.Add(new CartItem
                    {
                        Item = item,
                        Quantity = entry.Value
                    });
                }
            }
            return items;
        }
         private void OnItemsUpdated()
        {
            ItemsUpdated?.Invoke();
        }
        private void OnCartUpdated()
        {
            CartUpdated?.Invoke();
        }
    }
    public class CartItem
{
    public ItemDTO Item { get; set; }
    public int Quantity { get; set; }
    public double TotalPrice => Item.Price * Quantity ?? 0;

}
}

