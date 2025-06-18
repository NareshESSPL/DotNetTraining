using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add EF Core with SQL Server
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Add MVC (Controllers + Views)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ✅ Middleware pipeline configuration
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Custom error page
    app.UseHsts(); // Strict Transport Security
}

app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
app.UseStaticFiles();      // Serve static files (wwwroot)

app.UseRouting();          // Enable endpoint routing

app.UseAuthorization();    // Enables [Authorize] attribute functionality

// ✅ Map default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}/{id?}");

app.Run(); // Run the application
