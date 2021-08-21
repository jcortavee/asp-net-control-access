using AccessControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessControl.Configuration
{
    public class AccessTypeConfiguration : IEntityTypeConfiguration<AccessType>
    {
        public void Configure(EntityTypeBuilder<AccessType> builder)
        {
            builder.ToTable("AccessTypes");
            builder.HasData(
                new AccessType
                {
                    Id = 1,
                    Type = "Entrada"
                },
                new AccessType
                {
                    Id = 2,
                    Type = "Salida"
                });
        }
    }
}