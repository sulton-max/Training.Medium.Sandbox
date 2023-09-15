namespace Shared.Models.Entities;
public class PromotionMessage
{
    public string Title { get; set; }
    public string Body { get; set; }
    public string ActionText { get; set; }
    public string ActionUrl { get; set; }
    public string ImageUrl { get; set; }

    public PromotionMessage() { }

    public PromotionMessage(string title, string body, string actionText, string actionUrl, string imageUrl)
    {
        Title = title;
        Body = body;
        ActionText = actionText;
        ActionUrl = actionUrl;
        ImageUrl = imageUrl;
    }
}
