namespace Savodly.Domain.Entities;

public class Lesson : Auditable
{
    public int CourseId { get; set; }
    public string Name { get; set; }
    public int ModuleId { get; set; }

    public Course Course { get; set; }
    public Module Module { get; set; }
    public ICollection<LessonVideo> LessonsVideos { get; set; }
    public ICollection<LessonFile> LessonsFiles { get; set; }
    public LessonDocumentation LessonDocumentation { get; set; }
}
