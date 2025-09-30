using Microsoft.EntityFrameworkCore;
using Prescriptions.Models;           // <-- your DbContext namespace
using Microsoft.EntityFrameworkCore.Sqlite;

var builder = WebApplication.CreateBuilder(args);

// Pick SQLite path based on environment
// - Dev:   ./WalgreensPrescription.db
// - Azure: D:\home\data\WalgreensPrescription.db (Windows App Service)
string connectionString;
if (builder.Environment.IsDevelopment())
{
    connectionString = "Data Source=WalgreensPrescription.db";
}
else
{
    var azureDataDir = @"D:\home\data";
    Directory.CreateDirectory(azureDataDir); // ensure folder exists on Azure
    connectionString = $@"Data Source={Path.Combine(azureDataDir, "WalgreensPrescription.db")}";
}

// Register DbContext with SQLite
builder.Services.AddDbContext<PrescriptionDatabaseContext>(options =>
    options.UseSqlite(connectionString));

// MVC + Session
builder.Services.AddSession();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Apply EF migrations at startup (use EnsureCreated() if you don't use migrations)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PrescriptionDatabaseContext>();
    db.Database.Migrate();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

// Area route for Admin


// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
