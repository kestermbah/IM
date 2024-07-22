using System;
using System.Collections.Generic;
namespace InventoryManage;

public class Shop
{
    private ItemServiceProxy inv;
    private Dictionary<int, int> cart = new Dictionary<int, int>();
    public event Action ItemsUpdated;
    public event Action CartUpdated;


    public void AddOrUpdate(Item item) {
        inv.AddorUpdate(item);
        OnItemsUpdated();
    }

    public void Delete(Item item) {
         inv.Delete(item.Id);
         OnItemsUpdated();
    }


     public Shop(ItemServiceProxy itemService)
        {
            inv = itemService;
            inv.ItemsChanged += OnItemsUpdated;
        }


        public void AddToCart(int id, int quantity)
        {
            var item = inv.Items?.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                Console.WriteLine($"Item not found.");
                return;
            }
            if (quantity > item.Quantity)
            {
                Console.WriteLine($"Cannot add {quantity} of item '{item.Name}' to cart");
                return;
            }
            if (cart.ContainsKey(id))
            {
                cart[id] += quantity;
            }
            else
            {
                cart[id] = quantity;
            }
            item.Quantity -= quantity;
            inv.AddorUpdate(item);
            Console.WriteLine($"Added {quantity} of '{item.Name}' to cart.");
            OnItemsUpdated();
            OnCartUpdated();
        }
         public void RemoveFromCart(int id, int quantity)
        {
            if (!cart.ContainsKey(id))
            {
                Console.WriteLine($"Item not in cart.");
                return;
            }
            if (quantity > cart[id])
            {
                Console.WriteLine($"Cannot remove {quantity} of item with ID {id} from cart.");
                return;
            }
            cart[id] -= quantity;
            var item = inv.Items?.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.Quantity += quantity;
                inv.AddorUpdate(item);
            }
            if (cart[id] == 0)
            {
                cart.Remove(id);
            }
            Console.WriteLine($"Removed {quantity} of item with ID {id} from cart.");
            OnItemsUpdated();
            OnCartUpdated();
        }

        public void Checkout()
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Cart is empty.");
                return;
            }
            double subtotal = cart.Sum(i => inv.Items?.FirstOrDefault(x => x.Id == i.Key)?.Price * i.Value ?? 0);
            double tax = subtotal * 0.07;
            double total = subtotal + tax;
            Console.WriteLine("Recipt:");
            foreach (var item in cart)
            {
                var cartItem = inv.Items?.FirstOrDefault(i => i.Id == item.Key);
                if (cartItem == null)
                {
                    Console.WriteLine($"Item with ID {item.Key} not found.");
                    return;
                }
                Console.WriteLine($"Item: {cartItem.Name}, Quantity: {item.Value}");
        }
            Console.WriteLine($"Subtotal: {subtotal:C}");
            Console.WriteLine($"Tax (7%): {tax:C}");
            Console.WriteLine($"Total: {total:C}");


            cart.Clear();
            OnItemsUpdated();
            OnCartUpdated();
        }

        public IEnumerable<Item> GetItems() => inv.Items ?? Enumerable.Empty<Item>();

        public Dictionary<int, int> Cart => cart;
        private void OnItemsUpdated()
        {
            ItemsUpdated?.Invoke();
        }
         private void OnCartUpdated()
        {
            CartUpdated?.Invoke();
        }
    }
       
