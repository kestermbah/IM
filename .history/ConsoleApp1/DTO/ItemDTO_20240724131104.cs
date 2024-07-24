namespace InventoryManage;

public class ItemDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double? Price { get; set; }
    public int?Quantity { get; set; }
    public ItemDTO(Item P)
    {
        Id = P.Id;
        Name = P.Name;
        Description = P.Description;
        Price = P.Price;
        Quantity = P.Quantity;
    }
}
