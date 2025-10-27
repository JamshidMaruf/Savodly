namespace Savodly.Domain.Entities;

public class LessonFile : Auditable
{
    public int LessonId { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }

    public Lesson Lesson { get; set; }
}