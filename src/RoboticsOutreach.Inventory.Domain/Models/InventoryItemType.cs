namespace RoboticsOutreach.Inventory.Domain.Models;

/// <summary>
/// A type of item that can be inventoried.
/// </summary>
public class InventoryItemType : AuditableEntity
{
    /// <summary>
    /// The organisation that made this inventory item type.
    /// </summary>
    public Organisation? Manufacturer { get; set; }

    /// <summary>
    /// Whether this inventory item type is consumable. For consumables, the quantity of the item is tracked and the
    /// item does not have an asset tag.
    /// </summary>
    public bool IsConsumable { get; set; } = false;
    
    /// <summary>
    /// The name of the model of the inventory item type.
    /// </summary>
    public string? ModelName { get; set; }
    
    /// <summary>
    /// A description of the inventory item type.
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// The unit price of the inventory item type in pence.
    /// </summary>
    public int? UnitPrice { get; set; }
    
    /// <summary>
    /// The date that the unit price was last updated.
    /// </summary>
    public DateTime? UnitPriceDate { get; set; }
    
    /// <summary>
    /// Where to purchase the inventory item type.
    /// </summary>
    public Uri? ResupplyUri { get; set; }
    
    /// <summary>
    /// A list of bill of materials items that can be used to build this inventory item type.
    /// </summary>
    public IEnumerable<BomItem> BomItems { get; set; } = new List<BomItem>();
}