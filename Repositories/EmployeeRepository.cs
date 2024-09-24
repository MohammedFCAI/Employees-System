using EmployeeManagement.Contexts;
using EmployeeManagement.Entities;
using EmployeeManagement.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.Include(e => e.Department).ToList();
        }

        public Employee GetByIdAsNoTracking(int id)
        { 
            return _context.Employees.Include(e => e.Department).Include(e => e.Shift).AsNoTracking().FirstOrDefault(i => i.EmployeeId == id);
        }

        public Employee GetById(int id)
        {
            return _context.Employees.Include(e => e.Department).FirstOrDefault(i => i.EmployeeId == id);
        }

    }
}
