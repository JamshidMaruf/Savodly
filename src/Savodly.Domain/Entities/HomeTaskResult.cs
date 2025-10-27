namespace Savodly.Domain.Entities;

public class HomeTaskResult : Auditable
{
    public int LessonHomeTaskId { get; set; } 
    public int StudentId { get; set; }
    public int Point { get; set; }
    public string Feedback { get; set; }

    public Student Student { get; set; }
    public LessonHomeTask LessonHomeTask { get; set; }
}