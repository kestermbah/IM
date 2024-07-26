namespace IM.API;
using InventoryManage;
using Microsoft.AspNetCore.Http.Features;

public class InventoryEC
{
    public InventoryEC() {
        
    }

    public async Task<IEnumerable<ItemDTO>> Get()
    {
        return FakeDatabase.Items.Take(100).Select(c => new ItemDTO(c));
    }

    public async Task<ItemDTO> AddorUpdate(ItemDTO item)
   {
    var isAdd = false;

    if (item.Id == 0)
    {
        item.Id = FakeDatabase.LastID + 1; // Calculate new ID based on the current LastID
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

    return await Task.FromResult(item);
    }
    public async Task<ItemDTO?> Delete(int id)
        {
            var itemToDelete = FakeDatabase.Items.FirstOrDefault(p => p.Id == id);
            if (itemToDelete == null)
            {
                return null;
            }

            FakeDatabase.Items.Remove(itemToDelete);
            return new ItemDTO(itemToDelete);
        }

}
