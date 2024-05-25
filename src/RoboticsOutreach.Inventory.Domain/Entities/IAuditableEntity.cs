namespace RoboticsOutreach.Inventory.Domain.Models;

/// <summary>
/// An entity which tracks when it is created or updated.
/// </summary>
public interface IAuditableEntity : IIdentifiableEntity
{
    /// <summary>
    /// The date and time the entity was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// The date and time the entity was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}