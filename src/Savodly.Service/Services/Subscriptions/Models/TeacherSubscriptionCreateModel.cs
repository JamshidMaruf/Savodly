using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Savodly.Domain.Enums;

namespace Savodly.Service.Services.Supscriptions.Models;
public class TeacherSubscriptionCreateModel
{
    public int TeacherId { get; set; }
    public int SubscriptionId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TeacherSubscriptionStatus Status { get; set; }
}
