using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savodly.Service.Services.Supscriptions.Models;
public class SubscriptionCreateModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
}
