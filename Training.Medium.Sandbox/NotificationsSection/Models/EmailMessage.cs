using Shared.Models.Common;

namespace NotificationsSection.Models;


public class EmailMessage : SoftDeletedEntity
{
    public string Subject { get; set; }
    public string Body { get; set; }
    public string SenderAddress { get; set; }
    public string ReceiverAddress { get; set; }
    public bool IsSent { get; set; }
    public DateTime? SentDate { get; set; }


    public EmailMessage(string subject, string body, string senderAddress, string receiverAddress)
    {
        Id = Guid.NewGuid();
        Subject = subject;
        Body = body;
        SenderAddress = senderAddress;
        ReceiverAddress = receiverAddress;
        CreatedDate = DateTime.UtcNow;
        IsSent = false;
    }
}