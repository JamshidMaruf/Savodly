namespace Savodly.Domain.Entities;

public class Exam : Auditable
{
    public int CourseId { get; set; }
    public string Name { get; set; }

    public Course Course { get; set; }
}
