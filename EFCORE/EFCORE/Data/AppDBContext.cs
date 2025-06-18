
using Microsoft.EntityFrameworkCore;
using EFCORE.Entity;
namespace Data
{


    public class AppDBContext : DbContext
    {
      

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {}
        
           public DbSet<User> User { get; set; }
    }
    

}