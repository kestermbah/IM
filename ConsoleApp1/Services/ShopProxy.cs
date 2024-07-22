
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using InventoryManage.Models;

namespace InventoryManage.Services{
    public class ShopProxy{
        private static ShopProxy? instance;
        private static object instanceLock = new object();
        public ReadOnlyCollection<ShoppingCart> carts;

        public ShoppingCart Cart
        {
            get
            {
                if (carts == null || !carts.Any())
                {
                    return new ShoppingCart();
                }
                return carts?.FirstOrDefault() ?? new ShoppingCart();
            }
        }

        private ShopProxy() {
        }
        public static ShopProxy Current{
            get{
                lock (instanceLock)
                {
                if (instance == null)
                {
                    instance = new ShopProxy();
                }
                }
                return instance;
            }
        }

        public void AddToCart(Item p)
        {
            if (Cart == null)
            {
                return; 
            }
            var existingProduct = Cart?.contents?.FirstOrDefault(x => x.Id == p.Id);
            var inventoryProduct = ItemServiceProxy.Current.Items.FirstOrDefault(x => x.Id == p.Id);
            if (inventoryProduct == null)
            {
                return;
            }
            inventoryProduct.Quantity -= p.Quantity;

            if (existingProduct!= null)
            {
                existingProduct.Quantity += p.Quantity;
            } else
            {
                Cart?.contents?.Add(p);
            }
        }
        public ShoppingCart AddorUpdate(ShoppingCart c){

        }


    }
}