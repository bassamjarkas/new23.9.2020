using Microsoft.EntityFrameworkCore;

namespace ZwajApp.API.Model
{
    public class dbcontext:DbContext
    {
        public dbcontext(DbContextOptions<dbcontext> options):base(options)
        {
            
        }
        public DbSet<value> values {get; set;}
        public DbSet<User> Users { get; set; }

        public DbSet<Photo>  photo{ get; set; }
    
    }
}