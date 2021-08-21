using AccessControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessControl.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasData(
                new Role()
                {
                    Id = 1,
                    Name = "Admin"
                },
                new Role()
                {
                    Id = 2,
                    Name = "Employee"
                });
        }
    }
}