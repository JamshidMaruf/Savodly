using Savodly.Domain.Enums;

namespace Savodly.Domain.Entities;

public class QuizTest : Auditable
{
    public int QuizId { get; set; }
    public string Title { get; set; }
    public QuizTestType Type { get; set; }

    public Quiz Quiz { get; set; }
}