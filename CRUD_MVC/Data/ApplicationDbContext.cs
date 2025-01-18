using CRUD_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> StudentsMVC { get; set; }
    }
}
