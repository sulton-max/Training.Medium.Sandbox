using Shared.Models.Entities;

namespace MembershipSection.Services.Interfaces;

public interface ISubscriptionPromotionService
{
    PromotionMessage Get();
}