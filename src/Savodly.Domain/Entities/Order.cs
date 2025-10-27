using Savodly.Domain.Enums;

namespace Savodly.Domain.Entities;

public class Order : Auditable
{
    public int StudentId {  get; set; }
    public decimal TotalPrice { get; set;}
    public OrderStatus Status { get; set; }

    public Student Student { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}
