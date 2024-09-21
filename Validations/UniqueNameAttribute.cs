using EmployeeManagement.Contexts;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Validations
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            var departmentName = value as string;

            if (context.Departments.Any(d => d.DepartmentName.ToLower() == departmentName.ToLower()))
            {
                return new ValidationResult(ErrorMessage ?? "Department name must be unique.");
            }

            return ValidationResult.Success;
        }
    }

}
