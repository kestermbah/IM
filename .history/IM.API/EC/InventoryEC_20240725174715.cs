﻿namespace IM.API;
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

        if(item.Id == 0)
        {
            item.Id = FakeDatabase.LastID + 1;
            isAdd = true;
        }
        if(isAdd)
        {
            FakeDatabase.Items.Add(new Item(item)); 
        }
       return await Task.FromResult(item);
    }

}
