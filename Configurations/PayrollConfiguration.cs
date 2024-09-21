using EmployeeManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Configurations
{
    public class PayrollConfiguration : IEntityTypeConfiguration<Payroll>
    {
        public void Configure(EntityTypeBuilder<Payroll> builder)
        {
            builder.HasKey(p => p.PayrollId); // Primary Key

            builder.Property(p => p.BasicSalary)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); // Salary precision and scale

            builder.Property(p => p.Allowances)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Deductions)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.NetSalary)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); // Computed or calculated field

            builder.Property(p => p.PaymentDate)
                .IsRequired();

            builder.HasOne(p => p.Employee)
                .WithMany(e => e.Payrolls)
                .HasForeignKey(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade); // Foreign Key Relationship
        }
    }
}
