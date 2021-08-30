using AccessControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessControl.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            
            builder.HasData(
                new Employee()
                {
                    Id = 1,
                    EmployeeCode = "EMP001",
                    FirstName = "John",
                    LastName = "Doe",
                    UserId = 1
                });

        }
        
        
    }
}