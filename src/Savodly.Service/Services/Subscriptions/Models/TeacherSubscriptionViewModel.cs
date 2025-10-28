using Savodly.Domain.Entities;
using Savodly.Domain.Enums;

namespace Savodly.Service.Services.Supscriptions.Models;

public class TeacherSubscriptionViewModel
{
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public int SubscriptionId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TeacherSubscriptionStatus Status { get; set; }
    public Subscription Supscription { get; set; }
}
