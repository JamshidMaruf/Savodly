using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Savodly.Domain.Enums;
using Savodly.Service.Services.Courses.Models;

namespace Savodly.Service.Services.Courses;
public interface ICourseService
{
    Task CreateAsync(CourseCreateModel model);
    Task UpdateAsync(int id, CourseUpdateModel model);
    Task DeleteAsync(int id);
    Task<CourseViewModel> GetByIdAsync(int id);
    Task<List<CourseViewModel>> GetAllByTeacherIdAsync(int id);
    Task StudentAddAsync(StudentAddModel model);
    Task StudentRemoveAsync(int id);
    Task ChangeStatusAsync(int id, CourseStatus status);
}
