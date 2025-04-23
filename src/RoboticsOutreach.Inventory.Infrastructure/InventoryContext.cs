namespace RoboticsOutreach.Inventory.Infrastructure;

using Microsoft.EntityFrameworkCore;
using RoboticsOutreach.Inventory.Domain.Models;

public class InventoryContext : DbContext
{
    public DbSet<BomItem> BomItems { get; set; }
    public DbSet<InventoryItem> InventoryItems { get; set; }
    // public DbSet<InventoryItemState> InventoryItemStates { get; set; }
    public DbSet<InventoryItemType> InventoryItemTypes { get; set; }
    public DbSet<Organisation> Organisations { get; set; }

    public string DbPath { get; }

    public InventoryContext()
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        DbPath = Path.Join(path, "inventory.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InventoryItemType>()
            .HasMany(e => e.BomItems)
            .WithOne(e => e.ItemType);
        modelBuilder.Entity<BomItem>()
            .HasOne(e => e.IngredientType);
        base.OnModelCreating(modelBuilder);
    }
}
