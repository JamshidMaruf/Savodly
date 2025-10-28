using Savodly.Domain.Enums;
using Savodly.Service.Services.Courses.Models;
using Savodly.Service.Services.Supscriptions.Models;

namespace Savodly.Service.Services.Supscriptions;

public interface ISubscriptionService
{
    Task CreateAsync(SubscriptionCreateModel model);
    Task UpdateAsync(int id, SubscriptionUpdateModel model);
    Task DeleteAsync(int id);
    Task<SubscriptionViewModel> GetByIdAsync(int id);
    Task<List<SubscriptionViewModel>> GetAllAsync();
    Task AddOpportunityAsync(OpportunitiesAddModel model);
    Task RemoveOpportunityAsync(int supscriptionId, int opportunityId);
    Task AddTeacherSupscriptionAsync(TeacherSubscriptionCreateModel model);
    Task ChangeStatusAsync(int teacherSupscriptionId, TeacherSubscriptionStatus status);
    Task UpdateTeacherSupscriptionAsync(TeacherSubscriptionUpdateModel model);
    Task RemoveTeacherSupscriptionAsync(int teacherId);
    Task<TeacherSubscriptionViewModel> GetTeacherSupscriptionByIdAsync(int teacherId);

}
