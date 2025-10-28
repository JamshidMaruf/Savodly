namespace Savodly.Domain.Entities;

public class Subscription : Auditable
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Duration {  get; set; }

    public ICollection<SubscriptionOpportunity> SubscriptionOpportunities { get; set; }
    public ICollection<TeacherSubscription> TeacherSubscriptions { get; set; }
}