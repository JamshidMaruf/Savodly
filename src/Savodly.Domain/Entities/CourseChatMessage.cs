namespace Savodly.Domain.Entities;

public class CourseChatMessage : Auditable
{
    public int CourseChatId { get; set; }
    public string Message { get; set; } 
    public int CourseChatMemberId { get; set; }
    public int ParentId {  get; set; }

    public CourseChat CourseChat { get; set; }
    public CourseChatMember CourseChatMember { get; set; }
}

