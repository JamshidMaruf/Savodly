namespace Savodly.Domain.Entities;

public class Product : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    //product kimga tegishli bo'ladi teachergami?
}
