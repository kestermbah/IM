using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace InventoryManage;

public class ItemServiceProxy
{
    public ItemServiceProxy() {
        items = new List<Item>
        {
          new Item { Id = 1, Name = "Item 1", Description = "Description of Item 1", Price = 10, Quantity = 5 },
          new Item { Id = 2, Name = "Item 2", Description = "Description of Item 2", Price = 20, Quantity = 3 },
          new Item { Id = 3, Name = "Item 3", Description = "Description of Item 3", Price = 30, Quantity = 7 }
        };
       
    }
    

    private static ItemServiceProxy? instance;
    private static object instanceLock = new object();
    public static ItemServiceProxy Current
    {
        get
        {
            if (instance == null)
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ItemServiceProxy();
                    }
                }
            }
            return instance;
        }
    }
    private List<Item>? items;
    public ReadOnlyCollection<Item>? Items
    {
        get
        {
            return items?.AsReadOnly();
        }
    }
    public int LastID
    {
        get
        {
            if (items?.Any() ?? false)
            {
                return items?.Select(c => c.Id).Max()?? 0;
            }
            return 0; 
        }
    }

    public Item? AddorUpdate(Item item){
        if (items == null)
        {
            return null; 
        }

        var isAdd = false; 

        if(item.Id == 0)
        {
            item.Id = LastID + 1;
            isAdd = true;
        }
        if(isAdd)
        {
            items.Add(item);
            OnItemsChanged(); 
        }
        OnItemsChanged(); 
        return item;
    }

       public void Delete(int id)
        {
            if (items == null)
            {
                return;
            }
            var itemToDelete = items.FirstOrDefault(c => c.Id == id);
            
            if(itemToDelete != null)
            {
                items.Remove(itemToDelete);
                OnItemsChanged();
            }
        }
        public event Action ItemsChanged;

        protected virtual void OnItemsChanged()
        {
            ItemsChanged?.Invoke();
        }

}
