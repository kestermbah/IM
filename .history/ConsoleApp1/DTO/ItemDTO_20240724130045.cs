﻿namespace InventoryManage;

public class ItemDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double? Price { get; set; }
    public int?Quantity { get; set; }
}
