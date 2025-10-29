using Savodly.DataAccess.UnitOfWorks;
using Savodly.Service.Student.Models;

namespace Savodly.Service.Student;

public class StudentService(IUnitOfWork unitOfWork) : IStudentService
{
    public async Task CreateAsync(StudentCreateModel model)
    {
      unitOfWork.Students.Insert(new Domain.Entities.Student
      {
          FirstName = model.FirstName,
          LastName = model.LastName,
          PhoneNumber = model.PhoneNumber,
      });
        await unitOfWork.SaveAsync();

    }

    public async Task UpdateAsync(StudentUpdateModel model)
    {
        var existStudent = await unitOfWork.Students.SelectAsync(x => x.Id == model.Id)
            ?? throw new Exception("This user is not found!");
        existStudent.FirstName = model.FirstName;
        existStudent.LastName = model.LastName;
        existStudent.PhoneNumber = model.PhoneNumber;
        existStudent.DateOfBirth = model.DateOfBirth;
        unitOfWork.Students.Update(existStudent);
        await unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var existStudent = await unitOfWork.Students.SelectAsync(x => x.Id == id)
            ?? throw new Exception("This user is not found!");
        unitOfWork.Students.Delete(existStudent);
        await unitOfWork.SaveAsync();
    }
    public async Task<StudentViewModel> GetAsync(int id)
    {
        var student = await unitOfWork.Students.SelectAsync(x => x.Id == id)
            ?? throw new Exception("This user is not found!");
        return new StudentViewModel
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            FullName = $"{student.FirstName} {student.LastName}",
            PhoneNumber = student.PhoneNumber,
            DateOfBirth = student.DateOfBirth,
            CreatedAt = student.CreatedAt,
            UpdatedAt = student.UpdatedAt,
        };
    }

    public async Task<List<StudentViewModel>> GetAllAsync()
    {
        var students = unitOfWork.Students.SelectAllAsQueryable();
        return await students.Select(student => new StudentViewModel
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            FullName = $"{student.FirstName} {student.LastName}",
            PhoneNumber = student.PhoneNumber,
            DateOfBirth = student.DateOfBirth,
            CreatedAt = student.CreatedAt,
            UpdatedAt = student.UpdatedAt,
        }).;
        ToListAsync();
    }
    public async Task<List<StudentViewModel>> GetByCourseIdAsync(int courseId)
    {
        var students = unitOfWork.StudentCourses.SelectAllAsQueryable()
            .Where(sc => sc.CourseId == courseId)
            .Select(student => new StudentViewModel
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            FullName = $"{student.FirstName} {student.LastName}",
            PhoneNumber = student.PhoneNumber,
            DateOfBirth = student.DateOfBirth,
            CreatedAt = student.CreatedAt,
            UpdatedAt = student.UpdatedAt,
        }).ToListAsync();

    }

    public async Task<List<StudentViewModel>> GetByTeacherIdAsync(int teacherId)
    {
         return await  unitOfWork.StudentCourses.SelectAllAsQueryable()
            student 
            .Where(sc => sc.Course.TeacherId == teacherId)
            .Select(student => new StudentViewModel
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            FullName = $"{student.FirstName} {student.LastName}",
            PhoneNumber = student.PhoneNumber,
            DateOfBirth = student.DateOfBirth,
            CreatedAt = student.CreatedAt,
            UpdatedAt = student.UpdatedAt,
        }).ToListAsync();
    }

    public Task<bool> PhoneNumberExistsAsync(string phoneNumber)
    {
        return unitOfWork.Students.ExistsAsync(s => s.PhoneNumber == phoneNumber);

    }

   
}
