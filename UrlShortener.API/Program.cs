using Microsoft.EntityFrameworkCore;
using UrlShortener.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=./Data/urls.db"));

var app = builder.Build();

using (var scoped = app.Services.CreateScope())
{
    var db = scoped.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

    app.Run();
