using DataAccess;
using Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<PeopleDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello from API");

app.MapGet("/person/count", (PeopleDbContext db)
    => db.Contracts.Count()
    );

app.MapGet("/city/top20", (PeopleDbContext db)
    => db.Persons
    .Include(x => x.Address)
    .Where(x => x.Address != null)
    .GroupBy(x => x.Address.City)
    .ToList()
    .OrderByDescending(x => x.Count())
    .Take(20)
    .Select( x => new { City = x.Key, Count = x.Count() })
    );

app.MapGet("/person/email/{part}", (string part, PeopleDbContext db) =>
    db.Persons
        .Include(x => x.Address)
        .Include(x => x.Contracts)
        .Where(x => x.Email.Contains(part))
        .ToList()
);

app.Run();