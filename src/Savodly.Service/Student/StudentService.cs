using Savodly.Service.Student.Models;

namespace Savodly.Service.Student;

public class StudentService : IStudentService
{
    public async Task CreateAsync(StudentCreateModel model)
    {
        var existStudent = Repository.SelectAsQuaryable()
            .Where(s => s.PhoneNumber == model.PhoneNumber)
            .FirstOrDefault();

        if (existStudent != null)
            throw new ArgumentException("Bu telefon raqami  ro'yxatdan o'tgan");

        var student = new Student
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            DateOfBirth = model.DateOfBirth
        };

        await studentRepository.InsertAsync(student);
    }
    public async Task UpdateAsync(StudentUpdateModel model)
    {
        var existStudent = await studentRepository.SelectAsync(model.Id)
            ?? throw new NotFoundException("Student topilmadi");

        var duplicateStudent = studentRepository.SelectAsQuaryable()
            .Where(s => s.PhoneNumber == model.PhoneNumber && s.Id != model.Id)
            .FirstOrDefault();

        if (duplicateStudent != null)
            throw new ArgumentException("Bu telefon raqami boshqa student tomonidan ishlatilmoqda");

        existStudent.FirstName = model.FirstName;
        existStudent.LastName = model.LastName;
        existStudent.PhoneNumber = model.PhoneNumber;
        existStudent.DateOfBirth = model.DateOfBirth;

        await studentRepository.UpdateAsync(existStudent);
    }

    public async Task DeleteAsync(int id)
    {
        var existStudent = await studentRepository.SelectAsync(id)
            ?? throw new NotFoundException("Student topilmadi");

        var hasActiveCourses = studentCourseRepository.SelectAsQuaryable()
            .Any(sc => sc.StudentId == id);

        if (hasActiveCourses)
            throw new ArgumentException("Bu studentning aktiv kurslari mavjud, o'chirib bo'lmaydi");

        await studentRepository.DeleteAsync(id);
    }

    public Task<StudentViewModel> GetAsync(int id)
    {
        var existStudent = await studentRepository.SelectAllAsQueryable()
             .Include(s => s.StudentDetail)
             .FirstOrDefaultAsync(s => s.Id == id)
             ?? throw new NotFoundException($"Student is not found");
        return new StudentViewModel

        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            FullName = s.FirstName + " " + s.LastName,
            PhoneNumber = s.PhoneNumber,
            DateOfBirth = s.DateOfBirth,
            Age = DateTime.Now.Year - s.DateOfBirth.Year,
            CoursesCount = s.StudentCourses.Count(),
            HomeTasksCount = s.StudentHomeTasks.Count(),
            OrdersCount = s.Orders.Count(),
            CreatedAt = s.CreatedAt,
            UpdatedAt = s.UpdatedAt
        };
        
    }

    public async Task<List<StudentViewModel>> GetByCourseIdAsync(int courseId)
    {
        var studentIds = studentCourseRepository.SelectAsQuaryable()
            .Where(sc => sc.CourseId == courseId)
            .Select(sc => sc.StudentId)
            .Distinct()
            .ToList();

        var result = new List<StudentViewModel>();

        foreach (var studentId in studentIds)
        {
            try
            {
                var studentViewModel = await GetAsync(studentId);
                result.Add(studentViewModel);
            }
            catch (NotFoundException)
            {
                continue;
            }
        }

        return result;
    }

    public async Task<StudentViewModel> GetByPhoneNumberAsync(string phoneNumber)
    {
        var student = studentRepository.SelectAsQuaryable()
            .Where(s => s.PhoneNumber == phoneNumber)
            .FirstOrDefault()
            ?? throw new NotFoundException("Bu telefon raqami bilan student topilmadi");

        return await GetAsync(student.Id);
    }

    public async Task<bool> PhoneNumberExistsAsync(string phoneNumber)
    {
        var exists = studentRepository.SelectAsQuaryable()
            .Any(s => s.PhoneNumber == phoneNumber);

        return exists;
    }

    public Task<bool> PhoneNumberExistsAsync(string phoneNumber)
    {
        throw new NotImplementedException();
    }

    public Task<List<StudentViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<StudentViewModel>> GetByTeacherIdAsync(int teacherId)
    {
        throw new NotImplementedException();
    }
}
