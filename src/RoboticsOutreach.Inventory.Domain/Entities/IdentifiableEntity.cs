namespace RoboticsOutreach.Inventory.Domain.Models;

public abstract class IdentifiableEntity : Entity, IIdentifiableEntity
{
    public Guid Id { get; set; }
}