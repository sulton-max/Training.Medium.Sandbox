using Shared.Models.Common;

namespace Shared.Models.Entities;

public class EmailTemplate : SoftDeletedEntity
{
    public string Subject { get; set; }
    public string Body { get; set; }

    public EmailTemplate()
    {
        
    }
    public EmailTemplate(Guid id,string subject, string body)
    {
        Id = id;
        Subject = subject;
        Body = body;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Subject, Body);
    }
    public override bool Equals(object? obj)
    {
        return this.GetHashCode().Equals(obj.GetHashCode());
    }
    public override string ToString()
    {
        return $"Subject:{Subject}, Body:{Body}";
    }
}
