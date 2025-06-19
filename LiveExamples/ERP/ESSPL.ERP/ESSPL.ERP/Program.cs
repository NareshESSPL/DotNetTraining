using ESSPL.Manager.IdentityManagement;
using System;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using ESSPL.Repository;

namespace ESSPL.ERP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            //Dependency Injection
            builder.Services.AddTransient<IIdentityManager, IdentityManager>();


            builder.Services.AddDbContext<ESSPLERPDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConString")));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
