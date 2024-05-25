namespace RoboticsOutreach.Inventory.Domain.Models;

/// <summary>
/// A physical item that is part of the inventory.
/// </summary>
public class InventoryItem : AuditableEntity
{
    /// <summary>
    /// The type of the item.
    /// </summary>
    public required InventoryItemType ItemType { get; set; }
    
    /// <summary>
    /// The asset tag of the item. Consumable items do not have an asset tag.
    /// </summary>
    public string? AssetTag { get; set; }
    
    /// <summary>
    /// The serial number of the item.
    /// </summary>
    public string? SerialNumber { get; set; }
    
    /// <summary>
    /// The location of the item.
    /// </summary>
    public InventoryItem? Location { get; set; }
    
    
    /// <summary>
    /// The state of the item.
    /// </summary>
    public InventoryItemState State { get; set; } = InventoryItemState.Ok;
    
    
    /// <summary>
    /// A summary of the item.
    /// </summary>
    public string? Summary { get; set; }
    
    
    /// <summary>
    /// The price paid for the item in pence.
    /// </summary>
    public int? AcquiredPrice { get; set; }
    
    /// <summary>
    /// When the item was acquired.
    /// </summary>
    public DateTime? AcquiredAt { get; set; }
}