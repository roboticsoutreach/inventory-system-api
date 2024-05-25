namespace RoboticsOutreach.Inventory.Domain.Models;

/// <summary>
/// An entity that has an identifier.
/// </summary>
public interface IIdentifiableEntity
{
    /// <summary>
    /// The identifier of the entity.
    /// </summary>
    Guid Id { get; set; }
}