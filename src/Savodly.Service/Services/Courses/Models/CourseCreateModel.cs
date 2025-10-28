using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Savodly.Domain.Enums;

namespace Savodly.Service.Services.Courses.Models;
public class CourseCreateModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public CourseStatus Status { get; set; }
}
