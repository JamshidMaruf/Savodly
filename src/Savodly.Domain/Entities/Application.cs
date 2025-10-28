namespace Savodly.Domain.Entities;

public class Application : Auditable
{
    public int QuizId {  get; set; }
    public int StudentId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public Quiz Quiz { get; set; }
    public Student Student { get; set; }
    public QuizResult QuizResult { get; set; }
}