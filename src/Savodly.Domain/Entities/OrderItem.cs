namespace Savodly.Domain.Entities;

public class OrderItem : Auditable
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public decimal Price { get; set;}
    public int Count { get; set; }
    public decimal InlinePrice { get; set;}

    public Product Product { get; set; }
    public Order Order { get; set; }
}