using Final_Project_Api.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Api.Data.EntitiesConfiguration
{
    internal class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            builder
                .Property(property => property.Title).HasMaxLength(64);

            builder
                .HasMany(s => s.Doctors)
                .WithOne(d => d.Specialize)
                .HasForeignKey(d => d.SpecializeId);





        }
    }
}

