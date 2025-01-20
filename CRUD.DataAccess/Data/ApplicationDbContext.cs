using CRUD.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> StudentsMVC { get; set; }
    }
}
