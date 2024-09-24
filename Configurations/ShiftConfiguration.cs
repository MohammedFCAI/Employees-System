using EmployeeManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Configurations
{
    public class ShiftConfiguration : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.Property(s => s.StartTime)
                  .IsRequired();

            builder.Property(s => s.EndTime)
                  .IsRequired();

            builder.HasMany(s => s.Employees)
              .WithOne(e => e.Shift) // Each Employee belongs to one Shift
              .HasForeignKey(e => e.ShiftId) // Foreign Key in Employee class
              .OnDelete(DeleteBehavior.Restrict); // Optional: Prevent cascade delete
        }
    }
}
