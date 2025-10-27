namespace Savodly.Domain.Entities;

public class QuizResult : Auditable
{
    public int ApplicationId { get; set; }
    public int CorrectAnswer {  get; set; }
    public int WrongAnswer { get; set; }
    public double Score { get; set; }

    public Application Application { get; set;}
}