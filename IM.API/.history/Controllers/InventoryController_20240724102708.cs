using Microsoft.AspNetCore.Mvc;
using InventoryManage;


namespace IM.API
{
     [ApiController]
    [Route("[controller]")]
public class InventoryController: ControllerBase
{
    private readonly ILogger<InventoryController> _logger;
   public InventoryController(ILogger<InventoryController> logger)
   {
        _logger = logger;
    }
    [HttpGet()]
    public IEnumerable<Item> Get()
    {
        return new List<Item>
        {
          new Item { Id = 1, Name = "Item 1", Description = "Description of Item 1", Price = 10, Quantity = 5 },
          new Item { Id = 2, Name = "Item 2", Description = "Description of Item 2", Price = 20, Quantity = 3 },
          new Item { Id = 3, Name = "Item 3", Description = "Description of Item 3", Price = 30, Quantity = 7 }
        };
    }
}

}