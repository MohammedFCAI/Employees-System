using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EmployeeManagement.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }    
        public string FirstName { get; set; }      
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public DateTime DateOfBirth { get; set; }  
        public string Email { get; set; }          
        public string PhoneNumber { get; set; }    
        public DateTime DateOfJoining { get; set; }
        public Status Status { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }

        [ValidateNever]
        public Department? Department { get; set; } 

        [ValidateNever]
        public ICollection<Payroll>? Payrolls { get; set; }

        public int? ShiftId { get; set; }
        [ValidateNever]
        public Shift? Shift { get; set; }

    }

}
