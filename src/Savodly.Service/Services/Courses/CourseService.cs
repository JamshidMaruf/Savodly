using Microsoft.EntityFrameworkCore;
using Savodly.DataAccess.UnitOfWorks;
using Savodly.Domain.Entities;
using Savodly.Domain.Enums;
using Savodly.Service.Exceptions;
using Savodly.Service.Services.Courses.Models;

namespace Savodly.Service.Services.Courses;
public class CourseService(IUnitOfWork unitOfWork) : ICourseService
{
    public async Task CreateAsync(CourseCreateModel model)
    {
        unitOfWork.Courses.Insert(new Course
        {
            Name = model.Name,
            Description = model.Description,
            StartTime = model.StartTime,
            EndTime = model.EndTime,
            Status = model.Status
        });

        await unitOfWork.SaveAsync();
    }

    public async Task UpdateAsync(int id, CourseUpdateModel model)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(x => x.Id == id)
            ?? throw new NotFoundException("Course not found");

        existCourse.Name = model.Name;
        existCourse.Description = model.Description;
        existCourse.StartTime = model.StartTime;
        existCourse.EndTime = model.EndTime;
        existCourse.Status = model.Status;

        unitOfWork.Courses.Update(existCourse);

        await unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(x => x.Id == id)
            ?? throw new NotFoundException("Course not found");

        unitOfWork.Courses.Delete(existCourse);

        await unitOfWork.SaveAsync();
    }

    public async Task<CourseViewModel> GetByIdAsync(int id)
    {
        return await unitOfWork.Courses
            .SelectAllAsQueryable()
            .Select(x => new CourseViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Status = x.Status
            })
            .FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new NotFoundException("Course not found");
    }

    public async Task<List<CourseViewModel>> GetAllByTeacherIdAsync(int id)
    {
        return await unitOfWork.Courses
            .SelectAllAsQueryable()
            .Where(x => x.TeacherId == id)
            .Select(x => new CourseViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Status = x.Status
            })
            .ToListAsync();
    }

    public async Task StudentAddAsync(StudentAddModel model)
    {
        var course = await unitOfWork.Courses.SelectAsync(x => x.Id == model.CourseId)
            ?? throw new NotFoundException("Course not found");

        var status = CourseStatus.Upcoming;

        if (course.Status != CourseStatus.Upcoming)
        {
            status = CourseStatus.Active;
        }

        unitOfWork.StudentCourses.Insert(new StudentCourse
        {
            StudentId = model.StudentId,
            CourseId = model.CourseId,
            Status = (StudentCourseStatus)status
        });

        await unitOfWork.SaveAsync();
    }

    public async Task StudentRemoveAsync(int id)
    {
        var existStudentCourse = await unitOfWork.StudentCourses.SelectAsync(x => x.Id == id)
            ?? throw new NotFoundException("This student course is not found!");

        unitOfWork.StudentCourses.Delete(existStudentCourse);

        await unitOfWork.SaveAsync();
    }

    public async Task ChangeStatusAsync(int id, CourseStatus status)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(x => x.Id == id)
            ?? throw new NotFoundException("Course not found");

        existCourse.Status = status;

        unitOfWork.Courses.Update(existCourse);

        await unitOfWork.SaveAsync();
    }
}
