using Savodly.Domain.Enums;

namespace Savodly.Domain.Entities;

public class TeacherSubscription : Auditable
{
    public int TeacherId { get; set; }
    public int SubscriptionId {  get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TeacherSubscriptionStatus Status { get; set; } 
    
    public Teacher Teacher { get; set; }
    public Subscription Subscription { get; set; }
}