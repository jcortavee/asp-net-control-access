using Microsoft.EntityFrameworkCore;

namespace AccessControl.Models
{
    public sealed class ControlAccessContext : DbContext
    {
        public ControlAccessContext(DbContextOptions<ControlAccessContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<AccessType> AccessTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Access> Accesses { get; set; }
    }
}