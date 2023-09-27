using Shared.Models.Common;

namespace Shared.Models.Entities;

public class Email : AuditableEntity
{
    public Guid ReceiverUserId { get; set; }
    public string ReceiverEmailAddress { get; set; }
    public Guid SenderUserId { get; set; }
    public string SenderEmailAddress { get; set; }
    public string Subject { get; set; }
    public DateTimeOffset SendTime { get; set; }
    public string Body { get; set; }
    public bool IsSent { get; set; }
}