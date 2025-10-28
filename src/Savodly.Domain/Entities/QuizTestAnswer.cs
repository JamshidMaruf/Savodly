namespace Savodly.Domain.Entities;

public class QuizTestAnswer : Auditable
{
    public int ApplicationId { get; set; }
    public int QuizTestId { get; set; }

    public Application Application { get; set; }
    public QuizTest QuizTest { get; set; }
    public ICollection<QuizTestOption> QuizTestOptions { get; set; }
}
