using RoboticsOutreach.Inventory.Domain.Models;
using RoboticsOutreach.Inventory.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

using var inventoryContext = new InventoryContext();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapGet("/organisation", (String name) => {
    return Array.Find(organisations, org => org.Name == name);
})
.WithName("GetOrganisation");

app.Run();
