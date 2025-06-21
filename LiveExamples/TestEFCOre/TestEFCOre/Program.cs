using Microsoft.EntityFrameworkCore;
using TestEfCore.Manager;
using TestEFCore.Entity;
using TestEFCore.Repository;

namespace TestEFCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            //builder.Services.AddSingleton<IUserManager, UserManager>();

            builder.Services.AddTransient<IUserManager, GenericUserManager>();
            builder.Services.AddTransient<TestEFCore.Repository.IRepository<ESSPLUser>, TestEFCore.Repository.Repository<ESSPLUser>>();
            builder.Services.AddTransient<TestEFCore.Repository.IRepository<Role>, TestEFCore.Repository.Repository<Role>>();


            //DI DBContext with seeding
            builder.Services.AddDbContext<TestEFCoreDbContext>(options =>
                    options.UseSqlServer(
                        builder.Configuration.GetConnectionString("ConString"))
                                .UseSeeding((context, storeChanged) =>
                                {
                                    if (!context.Set<Role>().Any())
                                    {
                                        context.Set<Role>().Add(new Role { RoleID = 1, RoleName = "Admin" });
                                        context.SaveChanges();
                                    }
                                }));

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
