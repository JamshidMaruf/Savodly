namespace Savodly.Domain.Entities;

public class Student : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }

    public ICollection<StudentCourse> StudentCourses { get; set; }
    public ICollection<StudentHomeTask> StudentHomeTasks { get; set; }
    public ICollection<HomeTaskResult> HomeTaskResults { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<StudentPointHistory> StudentPointsHistories { get; set; }
}

