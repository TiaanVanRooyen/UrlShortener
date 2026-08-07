using Microsoft.EntityFrameworkCore;
using UrlShortener.API.Data;
using UrlShortener.API.Endpoints;
using UrlShortener.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUrlShorteningService, UrlShorteningService>();

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=./urls.db"));

var app = builder.Build();

using (var scoped = app.Services.CreateScope())
{
    var db = scoped.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.MapEnpoints();

app.Run();