using Savodly.Domain.Enums;

namespace Savodly.Domain.Entities;

public class Course : Auditable
{
    public string Name {  get; set; }
    public string Description {  get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public CourseStatus Status { get; set; }
    public int TeacherId { get; set; }
    
    public Teacher Teacher { get; set; }
    public ICollection<StudentCourse> StudentCourses { get; set; }
    public ICollection<Lesson> Lessons { get; set; }
    public ICollection<Module> Modules { get; set; }
    public ICollection<Exam> Exams { get; set; }
    public ICollection<Quiz> Quizes { get; set; }
}