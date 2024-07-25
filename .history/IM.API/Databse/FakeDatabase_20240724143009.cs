namespace IM.API;
using InventoryManage;
public static class FakeDatabase
{
    public static int LastID
      {
        get
        {
            if (Items?.Any() ?? false)
            {
                return Items?.Select(c => c.Id).Max()?? 0;
            }
            return 0; 
        }
    }
        public static List <Item> Items { get; set;} = new List<Item>{
          new Item { Id = 1, Name = "Item 1", Description = "Description of Item 1", Price = 10, Quantity = 5 },
          new Item { Id = 2, Name = "Item 2", Description = "Description of Item 2", Price = 20, Quantity = 3 },
          new Item { Id = 3, Name = "Item 3", Description = "Description of Item 3", Price = 30, Quantity = 7 },
          new Item { Id = 4, Name = "Item 4", Description = "Description of Item 4", Price = 30, Quantity = 7 }
        };
}
