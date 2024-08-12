using Microsoft.EntityFrameworkCore;
using WebAPI_new.Model;

namespace WebAPI_new
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options ) : base(options)
        {
            
        }
        public DbSet<Student> Students_new { get; set; }
    }
}
