using Savodly.Domain.Enums;

namespace Savodly.Domain.Entities;

public class StudentCourse : Auditable
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public StudentCourseStatus Status { get; set; }

    public Student Student { get; set; }
    public Course Course { get; set; }
}