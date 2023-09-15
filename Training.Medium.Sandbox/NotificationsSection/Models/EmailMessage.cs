namespace NotificationsSection.Models;

public class EmailMessage
{
    public string Subject { get; set; }
    public string Body { get; set; }
    public string FromEmailAddress { get; set; }
    public string ToEmailAddress { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public DateTime SendedTime { get; set; }
}
