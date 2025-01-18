using CRUD_Razor.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Razor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }

        public DbSet<Student> Students_Razor { get; set; }
    }
}
