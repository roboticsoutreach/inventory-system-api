namespace RoboticsOutreach.Inventory.Domain.Models;

/// <summary>
/// A person, group, legal entity or some other entity which owns, makes or uses items.
/// </summary>
public class Organisation : AuditableEntity
{
    /// <summary>
    /// The name of the organisation.
    /// </summary>
    public required string Name { get; set; }
}