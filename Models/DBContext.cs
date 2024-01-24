using Microsoft.EntityFrameworkCore;

namespace SpinelTest.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { 
        }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Visit> Visit { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Lookup> Lookup { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
