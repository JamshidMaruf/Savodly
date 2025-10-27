using Savodly.Domain.Enums;

namespace Savodly.Domain.Entities;

public class Quiz : Auditable
{
    public int CourseId { get; set; }
    public QuizType Type { get; set; }
    public string Name { get; set; }
    public int Duration { get; set; }
    public int TestCount { get; set; }

    public Course Course { get; set; }
}
