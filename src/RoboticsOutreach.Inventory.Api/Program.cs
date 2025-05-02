using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RoboticsOutreach.Inventory.Domain.Models;
using RoboticsOutreach.Inventory.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

using var db = new InventoryContext();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "SRO Inventory API",
        Description = "The API for SRO's inventory database"
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    options.IncludeXmlComments(Assembly.GetAssembly(typeof(Organisation)));  // Include docs from Domain
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPut("/organisations", async (string name) =>
{
    var org = new Organisation { Name = name };
    db.Organisations.Add(org);
    await db.SaveChangesAsync();
    return Results.Created("/organisations", org);
});
app.MapGet("/organisations", () =>
    db.Organisations
);
app.MapPatch("/organisations", async (Guid id, string name) =>
{
    await db.Organisations
        .Where(org => org.Id == id)
        .ExecuteUpdateAsync(setters =>
            setters.SetProperty(org => org.Name, name));
});
app.MapDelete("/organisations", async (Guid id) =>
{
    if (await db.Organisations.FindAsync(id) is Organisation org)
    {
        db.Organisations.Remove(org);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.MapGet("/inventory_items", () => db.InventoryItems);
app.MapDelete("/inventory_items", async (Guid id) =>
{
    if (await db.InventoryItems.FindAsync(id) is InventoryItem item)
    {
        db.InventoryItems.Remove(item);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.MapGet("/inventory_item_types", () => db.InventoryItemTypes);
app.MapDelete("/inventory_item_types", async (Guid id) =>
{
    if (await db.InventoryItemTypes.FindAsync(id) is InventoryItemType itemType)
    {
        db.InventoryItemTypes.Remove(itemType);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.MapGet("/bom_items", () => db.BomItems);
app.MapDelete("/bom_items", async (Guid id) =>
{
    if (await db.BomItems.FindAsync(id) is BomItem item)
    {
        db.BomItems.Remove(item);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();
