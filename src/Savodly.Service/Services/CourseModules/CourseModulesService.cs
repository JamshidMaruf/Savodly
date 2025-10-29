using Microsoft.EntityFrameworkCore;
using Savodly.DataAccess.UnitOfWorks;
using Savodly.Domain.Entities;
using Savodly.Service.Exceptions;
using Savodly.Service.Services.CourseModules.Models;

namespace Savodly.Service.Services.CourseModules;

public class CourseModulesService(IUnitOfWork unitOfWork) : ICourseModulesServcie
{
    public async Task CreateAsync(ModuleCreateModel model)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(x => x.Id == model.CourseId)
            ?? throw new NotFoundException("Course not found");

        unitOfWork.Modules.Insert(new Module
        {
            Name = model.Name,
            CourseId = model.CourseId
        });

        await unitOfWork.SaveAsync();
    }

    public async Task UpdateAsync(int id, ModuleUpdateModel model)
    {
        var existModule = await unitOfWork.Modules.SelectAsync(x => x.Id == id)
            ?? throw new NotFoundException("Module not found");

        var existCourse = await unitOfWork.Courses.SelectAsync(x => x.Id == model.CourseId)
            ?? throw new NotFoundException("Course not found");

        existModule.Name = model.Name;
        existModule.CourseId = model.CourseId;

        unitOfWork.Modules.Update(existModule);

        await unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var existModule = await unitOfWork.Modules.SelectAsync(x => x.Id == id)
            ?? throw new NotFoundException("Module not found");

        unitOfWork.Modules.Delete(existModule);

        await unitOfWork.SaveAsync();
    }

    public async Task<ModuleViewModel> GetByIdAsync(int id)
    {
        return await unitOfWork.Modules
            .SelectAllAsQueryable()
            .Select(x => new ModuleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CourseId = x.CourseId,
            })
            .FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new NotFoundException("Module not found");
    }

    public async Task<List<ModuleViewModel>> GetAllByCourseIdAsync(int courseId)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(x => x.Id == courseId)
            ?? throw new NotFoundException("Course not found");

        return await unitOfWork.Modules
            .SelectAllAsQueryable()
            .Where(x => x.CourseId == courseId)
            .Select(x => new ModuleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CourseId = x.CourseId,
            })
            .ToListAsync();
    }
}
