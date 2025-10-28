using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Savodly.Domain.Enums;

namespace Savodly.Service.Services.Courses.Models;
public class StudentAddModel
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public StudentCourseStatus Status { get; set; }
}
