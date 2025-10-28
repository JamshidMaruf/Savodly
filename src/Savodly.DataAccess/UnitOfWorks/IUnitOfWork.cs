using Savodly.DataAccess.Repositories;
using Savodly.Domain.Entities;

namespace Savodly.DataAccess.UnitOfWorks;
public interface IUnitOfWork
{
    IRepository<Application> Aplications { get; set; }
    IRepository<Course> Courses { get; set; }
    IRepository<CourseChat> CourseChats { get; set; }
    IRepository<CourseChatMember> CourseChatMembers { get; set; }
    IRepository<CourseChatMessage> CourseChatMessages { get; set; }
    IRepository<CourseChatMessageFile> CourseChatMessageFiles { get; set; }
    IRepository<Exam> Exams { get; set; }
    IRepository<HomeTaskResult> HomeTaskResults { get; set; }
    IRepository<Lesson> Lessons {  get; set; }
    IRepository<LessonDocumentation> LessonsDocumentations { get; set; }
    IRepository<LessonFile> LessonsFiles { get; set; }
    IRepository<LessonHomeTask> LessonHomeTasks { get; set; }

}
