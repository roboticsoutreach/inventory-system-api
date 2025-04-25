namespace RoboticsOutreach.Inventory.Domain.Models;


/// <summary>
/// An entity that has an identifier.
/// </summary>
public abstract class IdentifiableEntity : Entity, IIdentifiableEntity
{
    /// <summary>
    /// The identifier of the entity.
    /// </summary>
    public Guid Id { get; set; } = Guid.CreateVersion7();
}