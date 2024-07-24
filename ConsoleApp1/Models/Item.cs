namespace InventoryManage;

public class Item
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double? Price { get; set; }
    public int?Quantity { get; set; }
    
     /* public string? Display
        {
            get
            {
                return ToString();
            }
        }

      public override string ToString()
      {
        return $"Id: {Id}, Name: {Name}, Description: {Description}, Price: {Price}, Quantity: {Quantity}";
      } */

}
