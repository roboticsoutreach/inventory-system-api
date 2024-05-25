namespace RoboticsOutreach.Inventory.Domain.Models;

public abstract class IdentifiableEntity : IIdentifiableEntity
{
    public Guid Id { get; set; }
}