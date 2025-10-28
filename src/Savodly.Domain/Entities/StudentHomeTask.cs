namespace Savodly.Domain.Entities;

public class StudentHomeTask : Auditable
{
    public int StudentId { get; set; }
    public int LessonHomeTaskId {  get; set; }
    public string FileName {  get; set; }
    public string FilePath {  get; set; }

    public Student Student { get; set; }
    public LessonHomeTask LessonHomeTask { get; set; }
}