namespace Savodly.Domain.Entities;

public class CourseChatMember : Auditable
{
    public int CourseChatId {  get; set; }
    public int MemberId { get; set; }
    public string MemberType { get; set; }

    public CourseChat CourseChat { get; set; }
}

