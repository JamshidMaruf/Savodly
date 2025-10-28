namespace Savodly.Domain.Entities;

public class CourseChat : Auditable
{
    public int CourseId { get; set; }
    public int TeacherId {  get; set; }
    public string Name { get; set; }

    public Teacher Teacher { get; set; }
    public Course Course { get; set; }
    public ICollection<CourseChatMessage> CourseChatMessages { get; set; }
    public ICollection<CourseChatMember> CourseChatMembers { get; set; }
} 

