using System.Collections.ObjectModel;
using Newtonsoft.Json;
 

namespace InventoryManage;

public class ItemServiceProxy
{
    public ItemServiceProxy() {
        items = new List<ItemDTO>
        {
          new ItemDTO { Id = 1, Name = "Item 1", Description = "Description of Item 1", Price = 10, Quantity = 5 },
          new ItemDTO { Id = 2, Name = "Item 2", Description = "Description of Item 2", Price = 20, Quantity = 3 },
          new ItemDTO { Id = 3, Name = "Item 3", Description = "Description of Item 3", Price = 30, Quantity = 7 }
        };
        var response = new WebRequestHandler().Get("/inventory").Result; 
        items = JsonConvert.DeserializeObject<List<ItemDTO>>(response);
       
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
    private List<ItemDTO>? items;
    public ReadOnlyCollection<ItemDTO>? Items
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

    public ItemDTO? AddorUpdate(ItemDTO item){
        if (items == null)
        {
            return null; 
        }
  
            var result = new WebRequestHandler().Post("/inventory", item).Result;
            var response = new WebRequestHandler().Get("/inventory").Result; 
            items = JsonConvert.DeserializeObject<List<ItemDTO>>(response);
            OnItemsChanged();
            return JsonConvert.DeserializeObject<ItemDTO>(result);
    }

      public async Task<ItemDTO> Delete(int id)
        {
          
            var brokeItem = await new WebRequestHandler().Delete($"/{id}");
            var itemToDelete = JsonConvert.DeserializeObject<ItemDTO>(brokeItem);
            var response = new WebRequestHandler().Get("/inventory").Result; 
            items = JsonConvert.DeserializeObject<List<ItemDTO>>(response);
            OnItemsChanged();
            return itemToDelete;
        }
        public event Action ItemsChanged;

        protected virtual void OnItemsChanged()
        {
            ItemsChanged?.Invoke();
        }

}
