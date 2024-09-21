using EmployeeManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Interfaces
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetAll();
        public Employee GetByIdAsNoTracking(int id);
        public Employee GetById(int id);

    }
}
