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

}
