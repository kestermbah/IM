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
    public async Task<IEnumerable<ItemDTO>> Get()
    {
        return await new InventoryEC().Get();
    }
    [HttpPost()]
    public async Task<ItemDTO> AddorUpdate([FromBody] ItemDTO item)
    {
        return await new InventoryEC().AddorUpdate(item);
    }
     [HttpDelete("{id}")]
         public IActionResult Delete (int id)
        {
         var itemDTO = new InventoryEC().Delete(id);

        if (itemDTO != null)
        {
            return Ok(itemDTO); 
        }
        return NotFound(new { message = "Item not found" });
        }
    }
    

}

