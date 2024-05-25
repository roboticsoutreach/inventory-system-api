namespace RoboticsOutreach.Inventory.Domain.Models;

public abstract class AuditableEntity : IdentifiableEntity, IAuditableEntity
{
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}