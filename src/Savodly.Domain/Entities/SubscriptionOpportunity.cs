namespace Savodly.Domain.Entities;

public class SubscriptionOpportunity : Auditable
{
    public string Name { get; set; }
    public int SubscriptionId { get; set; }

    public Subscription Subscription { get; set; }
}