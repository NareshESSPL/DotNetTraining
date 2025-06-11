// 📦 Required using directives
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Survey_System.Interfaces; // For ISurvey
using Survey_System.Services; // For SurveyManager
using Microsoft.EntityFrameworkCore;
using Survey_System.Models; // EF Core services

// 🧱 Optional namespace (in ASP.NET Core 6+, top-level statements don't require it)
// But you can add one if organizing code
namespace Survey_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register DbContext with SQL Server
            builder.Services.AddDbContext<SurveyContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            // Register your service interface and implementation
            builder.Services.AddScoped<ISurvey, SurveyManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Survey}/{action=Index}/{id?}");

            app.Run();
        }
    }
}