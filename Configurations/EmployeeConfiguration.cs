using EmployeeManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Primary Key
            builder.HasKey(e => e.EmployeeId);

            // Properties Configuration
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50); // Setting Required and Max Length for FirstName

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50); // Setting Required and Max Length for LastName

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100); // Setting Required and Max Length for Email

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(15); // Setting Max Length for PhoneNumber (Optional)

            builder.Property(e => e.DateOfBirth)
                .IsRequired(); // Setting DateOfBirth as Required

            builder.Property(e => e.DateOfJoining)
                .IsRequired(); // Setting DateOfJoining as Required

            // Ignore Computed Property (FullName)
            builder.Ignore(e => e.FullName);


            // New: Status Property Configuration
            builder.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValue(Status.Active); // Setting default value to Active

            // New: Status Property Configuration
            builder.Property(e => e.Gender)
                .IsRequired();

            // Relationships
            builder.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade); // Setting up the relationship with Department

            builder.HasMany(e => e.Payrolls)
                .WithOne(p => p.Employee)
                .HasForeignKey(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade); // Setting up the relationship with Payrolls
        }
    }
}
