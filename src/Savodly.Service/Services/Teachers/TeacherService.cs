using Microsoft.EntityFrameworkCore;
using Savodly.DataAccess.UnitOfWorks;
using Savodly.Domain.Entities;
using Savodly.Service.Exceptions;
using Savodly.Service.Services.Teachers.Models;

namespace Savodly.Service.Services.Teachers;

public class TeacherService(IUnitOfWork unitOfWork) : ITeacherService
{
    public async Task CreateAsync(TeacherCreateModel model)
    {
        unitOfWork.Teachers.Insert(new Teacher
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
        });

        await unitOfWork.SaveAsync();
    }

    public async Task UpdateAsync(int id, TeacherUpdateModel model)
    {
        var existTeacher = await unitOfWork.Teachers.SelectAsync(x => x.Id == id)
            ?? throw new NotFoundException("This user is not found!");

        existTeacher.FirstName = model.FirstName;
        existTeacher.LastName = model.LastName;
        existTeacher.PhoneNumber = model.PhoneNumber;

        unitOfWork.Teachers.Update(existTeacher);

        await unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var existTeacher = await unitOfWork.Teachers.SelectAsync(x => x.Id == id)
            ?? throw new NotFoundException("This user is not found!");

        unitOfWork.Teachers.Delete(existTeacher);

        await unitOfWork.SaveAsync();
    }

    public async Task<List<TeacherViewModel>> GetAllAsync(string search)
    {
        var teachers = unitOfWork.Teachers.SelectAllAsQueryable()
            .Where(t => !t.IsDeleted);

        if (string.IsNullOrEmpty(search))
        {
            teachers = teachers.Where(t =>
                t.FirstName.Contains(search) ||
                t.LastName.Contains(search) ||
                t.PhoneNumber.Contains(search));
        }

        return await teachers.Select(t => new TeacherViewModel
        {
            Id = t.Id,
            FirstName = t.FirstName,
            LastName = t.LastName,
            PhoneNumber = t.PhoneNumber,
        })
            .ToListAsync();
    }

    public async Task<TeacherViewModel> GetByIdAsync(int id)
    {
        return await unitOfWork.Teachers
            .SelectAllAsQueryable()
            .Select(t => new TeacherViewModel
            {
                Id = t.Id,
                FirstName = t.FirstName,
                LastName = t.LastName,
                PhoneNumber = t.PhoneNumber,
            })
            .FirstOrDefaultAsync(t => t.Id == id)
            ?? throw new NotFoundException("This user not found!");
    }
}
