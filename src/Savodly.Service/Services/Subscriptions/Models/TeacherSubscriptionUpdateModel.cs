using Savodly.Domain.Enums;

namespace Savodly.Service.Services.Supscriptions.Models;

public class TeacherSubscriptionUpdateModel
{
    public int TeacherId { get; set; }
    public int SubscriptionId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TeacherSubscriptionStatus Status { get; set; }
}