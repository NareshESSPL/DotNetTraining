using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using EfCoreProject.Data;

namespace EfCoreProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. Add MVC and EF Core services
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultString")));

            // Optional: Swagger for API testing (if needed)
            // builder.Services.AddEndpointsApiExplorer();
            // builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // 2. Configure middleware
            if (app.Environment.IsDevelopment())
            {
                // Developer-friendly error page
                app.UseDeveloperExceptionPage();

                // Optional Swagger middleware
                // app.UseSwagger();
                // app.UseSwaggerUI();
            }
            else
            {
                // Production error handler
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts(); // Adds HTTP Strict Transport Security
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // 3. Define default routing
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Student}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
