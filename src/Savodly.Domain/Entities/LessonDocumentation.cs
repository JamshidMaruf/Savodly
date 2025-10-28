namespace Savodly.Domain.Entities;

public class LessonDocumentation : Auditable
{
    public int LessonId { get; set; }
    public string Text { get; set; }

    public Lesson Lesson { get; set; }
}