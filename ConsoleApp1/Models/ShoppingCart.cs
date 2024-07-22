namespace InventoryManage.Models;

public class ShoppingCart
{
    int ID{get; set;}
    public List<Item>? contents{get; set;}
}