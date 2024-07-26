namespace IM.API;
using InventoryManage;
using Microsoft.AspNetCore.Http.Features;

public class InventoryEC
{
    public InventoryEC() {
        
    }

    public async Task<IEnumerable<Item>> Get()
    {
        return FakeDatabase.Items;
    }

}
