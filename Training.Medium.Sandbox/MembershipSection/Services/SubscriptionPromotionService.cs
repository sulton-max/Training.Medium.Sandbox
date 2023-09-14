using MembershipSection.Services.Interfaces;
using Shared.Models.Entities;

namespace MembershipSection.Services;

public class SubscriptionPromotionService : ISubscriptionPromotionService
{
    public PromotionMessage Get()
    {
        var promotionMessage = new PromotionMessage();
        promotionMessage.Title = "Stay curious.";
        promotionMessage.Body = "Discover stories, thinking, and expertise from writers on any topic.";
        promotionMessage.ActionText = "Start reading";
        promotionMessage.ActionUrl = "\\login";
        promotionMessage.ImageUrl = "\\personalizedImageUrl";

        return promotionMessage;
    }
}
