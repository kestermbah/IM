/*

using System.Runtime.Intrinsics.Arm;

namespace InventoryManage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var itemSvc = ItemServiceProxy.Current;
            Shop shop = new Shop(itemSvc);
              while (true)
             {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Inventory Management");
            Console.WriteLine("2. Shop");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            string? choice = Console.ReadLine();

            if (choice == "1")
            {
                 InventoryManagementMenu(itemSvc);

            }
            else if (choice == "2")
            {
               ShopMenu(shop);
            }
            else if (choice == "3")
            {
                Console.WriteLine("Exiting.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
         }
        }

        static void InventoryManagementMenu (ItemServiceProxy itemService)
        {
            while (true)
            {
                Console.WriteLine("\nInventory Management:");
                Console.WriteLine("1. Create Item");
                Console.WriteLine("2. Read Items");
                Console.WriteLine("3. Update Item");
                Console.WriteLine("4. Delete Item");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Choose an option: ");
                string? choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter item name: ");
                    string? name = Console.ReadLine();
                    Console.Write("Enter item description: ");
                    string? description = Console.ReadLine();
                    Console.Write("Enter item price: ");
                    double price = double.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Enter item quantity: ");
                    int? quantity = int.TryParse(Console.ReadLine(), out int quantityValue) ? quantityValue : (int?)null;
                    itemService.AddorUpdate(new Item { Name = name, Description = description, Price = price, Quantity = quantity });
                }
                if (choice == "2")
                {

                 var xitems = itemService.Items;
                
                   if (xitems == null || !xitems.Any())
                    {
                        Console.WriteLine("No items in inventory.");
                        return;
                    }
                    foreach (var item in xitems)
                    {
                        Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Description: {item.Description}, Price: {item.Price}, Quantity: {item.Quantity}");
                    }
                }
                if (choice == "3")
                {
                   Console.Write("Enter item ID: ");
                    int id = int.Parse(Console.ReadLine());
                    var item = itemService.Items?.FirstOrDefault(i => i.Id == id);
                    if (item == null)
                    {
                        Console.WriteLine($"Item with ID {id} not found.");
                        return;
                    }
                    Console.Write("Enter new name: ");
                    item.Name = Console.ReadLine();
                    Console.Write("Enter new description: ");
                    item.Description = Console.ReadLine();
                    Console.Write("Enter new price: ");
                    item.Price = double.Parse(Console.ReadLine());
                    Console.Write("Enter new quantity: ");
                    item.Quantity = int.Parse(Console.ReadLine());
                    itemService.AddorUpdate(item);
                }
                if (choice == "4")
                {
                    Console.Write("Enter item id: ");
                    int deleteID = int.Parse(Console.ReadLine());
                    itemService.Delete(deleteID);
                }
                if (choice == "5")
                {
                    break;
                }
                 else
                {
                    Console.WriteLine("Invalid choice");
                }

            }
            }
        

        static void ShopMenu(Shop shop)
        {
            while (true)
            {
                Console.WriteLine("\nShop Menu:");
                Console.WriteLine("1. Add to Cart");
                Console.WriteLine("2. Remove from Cart");
                Console.WriteLine("3. Checkout");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Choose an option: ");
                string? choice = Console.ReadLine();
            

                if (choice == "1")
                {
                    Console.Write("Enter item ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Enter quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    shop.AddToCart(id, quantity);
                }
                else if (choice == "2")
                {
                    Console.Write("Enter item ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Enter quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    shop.RemoveFromCart(id, quantity);
                }
                else if (choice == "3")
                {
                    shop.Checkout();
                }
                else if (choice == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }
    }

        }

    */