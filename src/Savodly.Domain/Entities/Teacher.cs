namespace Savodly.Domain.Entities;

public class Teacher : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber {  get; set; }

    public ICollection<TeacherSubscription> Subscriptions { get; set; }
    public ICollection<Course> Courses { get; set; }
}