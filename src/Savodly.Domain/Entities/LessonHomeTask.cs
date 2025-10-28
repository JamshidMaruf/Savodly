namespace Savodly.Domain.Entities;

public class LessonHomeTask : Auditable
{ 
    public int LessonId { get; set; }
    public string Description { get; set; }

    public Lesson Lesson { get; set; }
    public ICollection<LessonHomeTaskFile> HomeTaskFiles { get; set; }
    public ICollection<StudentHomeTask> StudentHomeTasks { get; set; }
    public ICollection<HomeTaskResult> HomeTaskResults { get; set; }
}
