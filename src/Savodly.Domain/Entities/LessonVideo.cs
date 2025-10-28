namespace Savodly.Domain.Entities;

public class LessonVideo : Auditable
{
    public int LessonId { get; set; }
    public string LessonName { get; set; }
    public string VideoPath { get; set; }

    public Lesson Lesson { get; set; }
}