using Savodly.DataAccess.Context;
using Savodly.DataAccess.Repositories;
using Savodly.Domain.Entities;

namespace Savodly.DataAccess.UnitOfWorks;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public IRepository<Application> Aplications { get; } = new Repository<Application>(context);
    public IRepository<Course> Courses { get; } = new Repository<Course>(context);
    public IRepository<CourseChat> CourseChats { get; } = new Repository<CourseChat>(context);
    public IRepository<CourseChatMember> CourseChatMembers { get; } = new Repository<CourseChatMember>(context);
    public IRepository<CourseChatMessage> CourseChatMessages { get; } = new Repository<CourseChatMessage>(context);
    public IRepository<CourseChatMessageFile> CourseChatMessageFiles { get; } = new Repository<CourseChatMessageFile>(context);
    public IRepository<Exam> Exams { get; } = new Repository<Exam>(context);
    public IRepository<HomeTaskResult> HomeTaskResults  { get; } = new Repository<HomeTaskResult>(context);
    public IRepository<Lesson> Lessons { get; } = new Repository<Lesson>(context);
    public IRepository<LessonDocumentation> LessonsDocumentations { get; } = new Repository<LessonDocumentation>(context);
    public IRepository<LessonFile> LessonsFiles { get; } = new Repository<LessonFile>(context);
    public IRepository<LessonHomeTask> LessonHomeTasks { get; } = new Repository<LessonHomeTask>(context);
    public IRepository<LessonHomeTaskFile> LessonHomeTaskFiles { get; } = new Repository<LessonHomeTaskFile>(context);
    public IRepository<LessonVideo> LessonVideos { get; } = new Repository<LessonVideo>(context);
    public IRepository<Module> Modules { get; } = new Repository<Module>(context);
    public IRepository<OnlineLesson> OnlineLessons { get; } = new Repository<OnlineLesson>(context);
    public IRepository<Order> Orders { get; } = new Repository<Order>(context);
    public IRepository<OrderItem> OrderItems { get; } = new Repository<OrderItem>(context);
    public IRepository<PointSetting> PointSettings { get; } = new Repository<PointSetting>(context);
    public IRepository<Product> Products { get; } = new Repository<Product>(context);
    public IRepository<Quiz> Quizes { get; } = new Repository<Quiz>(context);
    public IRepository<QuizResult> QuizResults { get; } = new Repository<QuizResult>(context);
    public IRepository<QuizTest> QuizTests { get; } = new Repository<QuizTest>(context);
    public IRepository<QuizTestAnswer> QuizTestAnswers { get; } = new Repository<QuizTestAnswer>(context);
    public IRepository<QuizTestOption> QuizTestOptions { get; } = new Repository<QuizTestOption>(context);
    public IRepository<Student> Students { get; } = new Repository<Student>(context);
    public IRepository<StudentCourse> StudentCourses { get; } = new Repository<StudentCourse>(context);
    public IRepository<StudentHomeTask> StudentHomeTasks { get; } = new Repository<StudentHomeTask>(context);
    public IRepository<StudentPointHistory> StudentPointHistories { get; } = new Repository<StudentPointHistory>(context);
    public IRepository<Subscription> Subscriptions { get; } = new Repository<Subscription>(context);
    public IRepository<SubscriptionOpportunity> SubscriptionsOpportunities { get; } = new Repository<SubscriptionOpportunity>(context);
    public IRepository<Teacher> Teachers { get; } = new Repository<Teacher>(context);
    public IRepository<TeacherSubscription> TeacherSubscriptions { get; } = new Repository<TeacherSubscription>(context);
    public IRepository<Setting> Settings { get; } = new Repository<Setting>(context);

    public async Task BeginTransactionAsync()
    {
        await context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await context.Database.BeginTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await context.Database.RollbackTransactionAsync();
    }

    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }

    public void Dispose()
    {
        context.Dispose();
        GC.SuppressFinalize(this);
    }
}