namespace RoboticsOutreach.Inventory.Infrastructure;

using Microsoft.EntityFrameworkCore;
using RoboticsOutreach.Inventory.Domain.Models;

public class InventoryContext : DbContext
{
    public DbSet<BomItem> BomItems { get; set; }
    public DbSet<InventoryItem> InventoryItems { get; set; }
    public DbSet<InventoryItemType> InventoryItemTypes { get; set; }
    public DbSet<Organisation> Organisations { get; set; }

    // The following configures EF to connect to a Postgres database
    // according to the set connection string.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql("Host=localhost; Database=sroinventory; Username=postgres;Password=postgres");  // TODO: don't have this hardcoded

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
