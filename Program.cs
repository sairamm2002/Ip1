using Microsoft.EntityFrameworkCore;
using Prescriptions.Models;

var builder = WebApplication.CreateBuilder(args);

// Detect HOME env var (exists on Azure App Service)
// Else, fallback to local project folder
var home = Environment.GetEnvironmentVariable("HOME");
string dataDir;

if (string.IsNullOrEmpty(home))
{
    // Local environment → store DB in current project folder
    dataDir = Path.Combine(Directory.GetCurrentDirectory(), "data");
}
else
{
    // Azure App Service → HOME points to D:\home
    dataDir = Path.Combine(home, "data");
}

// Make sure folder exists
Directory.CreateDirectory(dataDir);

// Full database path
var dbPath = Path.Combine(dataDir, "app.db");

// Register DbContext with SQLite
builder.Services.AddDbContext<PrescriptionDatabaseContext>(opt =>
    opt.UseSqlite($"Data Source={dbPath}"));

var app = builder.Build();

// Apply migrations on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PrescriptionDatabaseContext>();
    db.Database.Migrate();
}

app.MapDefaultControllerRoute();
app.Run();
