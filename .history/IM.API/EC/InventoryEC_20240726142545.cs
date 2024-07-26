namespace IM.API;
using InventoryManage;
using IM.API.Databse;
using Microsoft.AspNetCore.Http.Features;

public class InventoryEC
{
    public InventoryEC() {
        
    }

    public async Task<IEnumerable<ItemDTO>> Get()
    {
        return Filebase.Current.Items.Select(c => new ItemDTO(c));
    }

    public async Task<ItemDTO> AddorUpdate(ItemDTO p)
   {
    /* var isAdd = false;

    if (item.Id == 0)
    {
        item.Id = Filebase.Current.LastID + 1; // Calculate new ID based on the current LastID
        isAdd = true;
    }

    if (isAdd)
    {
        FakeDatabase.Items.Add(new Item(item));
    }
    else
    {
        var existingItem = FakeDatabase.Items.FirstOrDefault(i => i.Id == item.Id);
        if (existingItem != null)
        {
            existingItem.Name = item.Name;
            existingItem.Description = item.Description;
            // Update other fields as necessary
        }
    }

    return await Task.FromResult(item); */
    return new ItemDTO(Filebase.Current.AddOrUpdate(new Item(p)));
    }
    public async Task<ItemDTO?> Delete(int id)
        {
            return new ItemDTO(Filebase.Current.Delete(id));
            /* var itemToDelete = FakeDatabase.Items.FirstOrDefault(p => p.Id == id);
            if (itemToDelete == null)
            {
                return null;
            }

            FakeDatabase.Items.Remove(itemToDelete);
            return new ItemDTO(itemToDelete); */
        }

}
