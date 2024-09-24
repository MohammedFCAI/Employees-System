using EmployeeManagement.Entities;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModel
{
    public class EmployeeViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfJoining { get; set; }
        public Status Status { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public IEnumerable<Department>? Departments { get; set; }

        public int ShiftId { get; set; }
        public IEnumerable<Shift>? Shifts { get; set; }
    }
}
