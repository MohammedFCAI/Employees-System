using EmployeeManagement.Validations;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Entities
{
    public class Shift
    {
        public int Id { get; set; }

        [UniqueName]
        public string Name { get; set; } // e.g., Morning, Evening, Night shifts
        public TimeSpan StartTime { get; set; } // Shift start time
        public TimeSpan EndTime { get; set; } // Shift end time

        // Navigation Property to Employees
        public ICollection<Employee>? Employees { get; set; } // Many-to-many relationship with Employee

    }
}
