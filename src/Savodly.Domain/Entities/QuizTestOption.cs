namespace Savodly.Domain.Entities;

public class QuizTestOption : Auditable
{
    public string Name { get; set; }
    public bool IsCorrect { get; set; }

    public QuizTestAnswer QuizTestAnswer { get; set; }
}
