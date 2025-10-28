namespace Savodly.Domain.Entities;

public class LessonHomeTaskFile : Auditable
{
    public int LessonHomeTaskId { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }

    public LessonHomeTask LessonHomeTask { get; set; }
}