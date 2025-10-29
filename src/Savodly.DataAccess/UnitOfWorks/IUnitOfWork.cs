using Savodly.DataAccess.Repositories;
using Savodly.Domain.Entities;

namespace Savodly.DataAccess.UnitOfWorks;
public interface IUnitOfWork : IDisposable
{
    IRepository<Application> Aplications { get; }
    IRepository<Course> Courses { get; }
    IRepository<CourseChat> CourseChats { get;}
    IRepository<CourseChatMember> CourseChatMembers { get; }
    IRepository<CourseChatMessage> CourseChatMessages { get; }
    IRepository<CourseChatMessageFile> CourseChatMessageFiles { get; }
    IRepository<Exam> Exams { get; }
    IRepository<HomeTaskResult> HomeTaskResults { get; }
    IRepository<Lesson> Lessons { get; }
    IRepository<LessonDocumentation> LessonsDocumentations { get; }
    IRepository<LessonFile> LessonsFiles { get; }
    IRepository<LessonHomeTask> LessonHomeTasks { get; }
    IRepository<LessonHomeTaskFile> LessonHomeTaskFiles { get; }
    IRepository<LessonVideo> LessonVideos { get; }
    IRepository<Module> Modules { get; }
    IRepository<OnlineLesson> OnlineLessons { get; }
    IRepository<Order> Orders { get; }
    IRepository<OrderItem> OrderItems { get; }
    IRepository<PointSetting> PointSettings { get; }
    IRepository<Product> Products { get; }
    IRepository<Quiz> Quizes { get; }
    IRepository<QuizResult> QuizResults { get; }
    IRepository<QuizTest> QuizTests { get; }
    IRepository<QuizTestAnswer> QuizTestAnswers { get; }
    IRepository<QuizTestOption> QuizTestOptions { get; }
    IRepository<Student> Students { get; }
    IRepository<StudentCourse> StudentCourses { get; }
    IRepository<StudentHomeTask> StudentHomeTasks { get; }
    IRepository<StudentPointHistory> StudentPointHistories { get; }
    IRepository<Subscription> Subscriptions { get; }
    IRepository<SubscriptionOpportunity> SubscriptionsOpportunities { get; }
    IRepository<Teacher> Teachers { get; }
    IRepository<TeacherSubscription> TeacherSubscriptions {  get; }
    IRepository<Setting> Settings { get; }
    object StudentsCourses { get; }

    Task SaveAsync();
    Task CommitAsync();
    Task BeginTransactionAsync();
    Task RollbackTransactionAsync();
}