using AccessControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessControl.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            
            builder.HasData(
                new User()
                {
                    Id = 1,
                    Username = "Admin",
                    Password = "Pass1234",
                    RoleId = 1
                });

        }
        
        
    }
}