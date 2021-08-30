using AccessControl.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Models
{
    public sealed class ControlAccessContext : DbContext
    {
        public ControlAccessContext(DbContextOptions<ControlAccessContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccessTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

        public DbSet<AccessType> AccessTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Access> Accesses { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}