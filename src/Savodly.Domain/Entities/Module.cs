namespace Savodly.Domain.Entities;

public class Module : Auditable
{
    public string Name { get; set; }
    public int CourseId { get; set; }

    public Course Course { get; set; }
    public ICollection<Lesson> Lessons { get; set; }
}