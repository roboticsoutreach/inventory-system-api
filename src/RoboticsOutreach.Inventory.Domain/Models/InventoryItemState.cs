namespace RoboticsOutreach.Inventory.Domain.Models;

/// <summary>
/// The state of an inventory item.
/// </summary>
public enum InventoryItemState
{
    /// <summary>
    /// The item is in good condition and can be found in a location.
    /// </summary>
    Ok,
    
    /// <summary>
    /// The item is damaged.
    /// </summary>
    Damaged,
    
    /// <summary>
    /// The item is lost. The item is not in the location it is expected to be.
    /// </summary>
    Lost,
    
    /// <summary>
    /// The item was imported from another system and has not been verified or placed in a location.
    /// </summary>
    Orphaned,
}