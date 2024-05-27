using System.Collections.ObjectModel;

namespace InventoryManage;

public class ItemServiceProxy
{
    private ItemServiceProxy() {
        items = new List<Item>();
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
        }
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
            }
        }

}
