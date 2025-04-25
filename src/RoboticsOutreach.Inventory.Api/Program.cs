using System.Reflection;
using Microsoft.OpenApi.Models;
using RoboticsOutreach.Inventory.Domain.Models;
using RoboticsOutreach.Inventory.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

using var db = new InventoryContext();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo {
        Version = "v1",
        Title = "SRO Inventory API",
        Description = "The API for SRO's inventory database"
    });
    
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    options.IncludeXmlComments(Assembly.GetAssembly(typeof(Organisation)));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var organisations = new[] {
    new Organisation {Name = "Organisation 1"}, new Organisation {Name = "Organisation 2"}
};

app.MapGet("/organisations", (string? q) => {
    return db.Organisations;
})
.WithName("GetOrganisation");

app.MapGet("/inventory_items", () => db.InventoryItems);

app.MapGet("/inventory_item_types", () => db.InventoryItemTypes);

app.MapGet("/bom_items", () => db.BomItems);

app.Run();
