namespace RoboticsOutreach.Inventory.Domain.Models;

/// <summary>
/// An item in a bill of materials. Item types can have other item types as "ingredients".
/// </summary>
public class BomItem : Entity
{
    /// <summary>
    /// The item type that is "built" by this bill of materials item.
    /// </summary>
    public required InventoryItemType ItemType { get; set; }

    /// <summary>
    /// The item type that is used as an ingredient in this bill of materials item.
    /// </summary>
    public required InventoryItemType IngredientType { get; set; }

    /// <summary>
    /// The quantity of the ingredient required to build the item.
    /// </summary>
    public int Quantity { get; set; } = 1;
}