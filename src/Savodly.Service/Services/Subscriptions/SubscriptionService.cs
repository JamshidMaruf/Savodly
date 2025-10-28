using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Savodly.DataAccess.UnitOfWorks;
using Savodly.Domain.Entities;
using Savodly.Domain.Enums;
using Savodly.Service.Services.Supscriptions.Models;

namespace Savodly.Service.Services.Supscriptions;
public class SubscriptionService(IUnitOfWork unitOfWork) : ISubscriptionService
{
    public async Task AddOpportunityAsync(OpportunitiesAddModel model)
    {
        unitOfWork.SubscriptionsOpportunities.Insert(new SubscriptionOpportunity
        {
            SubscriptionId = model.SubscriptionId,
            Name = model.Name,
        });

        await unitOfWork.SaveAsync();
    }

    public async Task ChangeStatusAsync(int teacherSupscriptionId, TeacherSubscriptionStatus status)
    {
        var existTeacherSupscription = await unitOfWork.TeacherSubscriptions
            .SelectAsync(x => x.Id == teacherSupscriptionId)
            ?? throw new Exception("Teacher supscription not found");

        existTeacherSupscription.Status = status;

        unitOfWork.TeacherSubscriptions.Update(existTeacherSupscription);

        await unitOfWork.SaveAsync();
    }

    public async Task CreateAsync(SubscriptionCreateModel model)
    {
        unitOfWork.Subscriptions.Insert(new Subscription
        {
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            Duration = model.Duration,
        });

        await unitOfWork.SaveAsync();
    }

    public async Task AddTeacherSupscriptionAsync(TeacherSubscriptionCreateModel model)
    {
        unitOfWork.TeacherSubscriptions.Insert(new TeacherSubscription
        {
            TeacherId = model.TeacherId,
            SubscriptionId = model.SubscriptionId,
            Status = TeacherSubscriptionStatus.Enable,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
        });

        await unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var existSupscription = await unitOfWork.Subscriptions.SelectAsync(x => x.Id == id)
            ?? throw new Exception("Supscription not found"); 

        unitOfWork.Subscriptions.Delete(existSupscription);

        await unitOfWork.SaveAsync();
    }

    public async Task RemoveTeacherSupscriptionAsync(int teacherId)
    {
        var existTeacherSupscription = await unitOfWork.TeacherSubscriptions
            .SelectAsync(x => x.TeacherId == teacherId)
            ?? throw new Exception("Teacher supscription not found");

        unitOfWork.TeacherSubscriptions.Delete(existTeacherSupscription);

        await unitOfWork.SaveAsync();
    }

    public async Task<List<SubscriptionViewModel>> GetAllAsync()
    {
        return await unitOfWork.Subscriptions
            .SelectAllAsQueryable()
            .Where(x => !x.IsDeleted)
            .Select(x => new SubscriptionViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Duration = x.Duration,
            })
            .ToListAsync();
    }

    public async Task<SubscriptionViewModel> GetByIdAsync(int id)
    {
        return await unitOfWork.Subscriptions
            .SelectAllAsQueryable()
            .Where(x => x.Id == id && !x.IsDeleted)
            .Select(x => new SubscriptionViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Duration = x.Duration,
            })
            .FirstOrDefaultAsync()
            ?? throw new Exception("Supscription not found");
    }

    public async Task<TeacherSubscriptionViewModel> GetTeacherSupscriptionByIdAsync(int teacherId)
    {
        var teacherSubscription = await unitOfWork.TeacherSubscriptions
            .SelectAllAsQueryable()
            .Where(ts => !ts.IsDeleted)
            .Include(ts => ts.Subscription)
            .FirstOrDefaultAsync(ts => ts.TeacherId == teacherId)
            ?? throw new Exception("Teacher subscription not found");

        return new TeacherSubscriptionViewModel
        {
            Id = teacherSubscription.Id,
            TeacherId = teacherSubscription.TeacherId,
            SubscriptionId = teacherSubscription.SubscriptionId,
            Status = teacherSubscription.Status,
            StartDate = teacherSubscription.StartDate,
            EndDate =  teacherSubscription.EndDate,
            Supscription = teacherSubscription.Subscription,
        };  
    }


    public async Task RemoveOpportunityAsync(int supscriptionId, int opportunityId)
    {
        var existOpportunity = await unitOfWork.SubscriptionsOpportunities
            .SelectAsync(x => x.Id == opportunityId && x.SubscriptionId == supscriptionId)
            ?? throw new Exception("Opportunity not found");

        unitOfWork.SubscriptionsOpportunities.Delete(existOpportunity);

        await unitOfWork.SaveAsync();
    }

    public async Task UpdateAsync(int id, SubscriptionUpdateModel model)
    {
        var existSupscription = await unitOfWork.Subscriptions.SelectAsync(x => x.Id == id)
            ?? throw new Exception("Supscription not found");

        existSupscription.Name = model.Name;
        existSupscription.Description = model.Description;
        existSupscription.Price = model.Price;
        existSupscription.Duration = model.Duration;

        unitOfWork.Subscriptions.Update(existSupscription);

        await unitOfWork.SaveAsync();
    }

    public async Task UpdateTeacherSupscriptionAsync(TeacherSubscriptionUpdateModel model)
    {
        var existTeacherSupscription = await unitOfWork.TeacherSubscriptions
            .SelectAsync(x => x.Id == model.TeacherId)
            ?? throw new Exception("Teacher supscription not found");

        existTeacherSupscription.SubscriptionId = model.SubscriptionId;
        existTeacherSupscription.StartDate = model.StartDate;
        existTeacherSupscription.EndDate = model.EndDate;

        unitOfWork.TeacherSubscriptions.Update(existTeacherSupscription);

        await unitOfWork.SaveAsync();
    }
}
