namespace Savodly.Service.Services.Supscriptions.Models;

public class SubscriptionViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
}

