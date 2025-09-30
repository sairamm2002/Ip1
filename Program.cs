using Microsoft.EntityFrameworkCore;

using Prescriptions.Models;
var builder = WebApplication.CreateBuilder(args);

var home = Environment.GetEnvironmentVariable("HOME") ?? @"D:\home";
var dataDir = Path.Combine(home, "data");
Directory.CreateDirectory(dataDir);
var dbPath = Path.Combine(dataDir, "app.db");

builder.Services.AddDbContext<PrescriptionDatabaseContext>(opt =>
    opt.UseSqlite($"Data Source={dbPath}"));

var app = builder.Build();

// Optional: apply EF migrations on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PrescriptionDatabaseContext>();
    db.Database.Migrate();
}

app.MapDefaultControllerRoute();
app.Run();
