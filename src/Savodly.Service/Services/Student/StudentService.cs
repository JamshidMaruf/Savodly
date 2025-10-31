using Microsoft.EntityFrameworkCore;
using Savodly.DataAccess.UnitOfWorks;
using Savodly.Service.Exceptions;
using Savodly.Service.Student.Models;
using Savodly.Domain.Entities;



namespace Savodly.Service.Student;

public class StudentService(IUnitOfWork unitOfWork) : IStudentService
{
    public async Task CreateAsync(StudentCreateModel model)
    {
        unitOfWork.Students.Insert(new Student
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            DateOfBirth = model.DateOfBirth,
        });
        await unitOfWork.SaveAsync();
    }

    public async Task UpdateAsync(int id, StudentUpdateModel model)
    {
        var existStudent = await unitOfWork.Students.SelectAsync(x => x.Id == id)
            ?? throw new NotFoundException("This student is not found!");

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
            ?? throw new NotFoundException("This student is not found!");

        unitOfWork.Students.Delete(existStudent);
        await unitOfWork.SaveAsync();
    }

    public async Task<List<StudentViewModel>> GetAllAsync(string search)
    {
        var students = unitOfWork.Students.SelectAllAsQueryable()
            .Where(s => !s.IsDeleted);

        if (!string.IsNullOrEmpty(search))
        {
            students = students.Where(s =>
                s.FirstName.Contains(search) ||
                s.LastName.Contains(search) ||
                s.PhoneNumber.Contains(search));
        }

        return await students.Select(s => new StudentViewModel
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            PhoneNumber = s.PhoneNumber,
            DateOfBirth = s.DateOfBirth,
        })
        .ToListAsync();
    }

    public async Task<StudentViewModel> GetByIdAsync(int id)
    {
        return await unitOfWork.Students
            .SelectAllAsQueryable()
            .Select(s => new StudentViewModel
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                PhoneNumber = s.PhoneNumber,
                DateOfBirth = s.DateOfBirth,
            })
            .FirstOrDefaultAsync(s => s.Id == id)
            ?? throw new NotFoundException("This student not found!");
    }

    public Task<List<StudentViewModel>> GetAllByTeacherIdAsync(int teacherId)
    {
        throw new NotImplementedException();
    }

    public Task<List<StudentViewModel>> GetAllByCourseIdAsync(int courseId)
    {
        throw new NotImplementedException();
    }
}
