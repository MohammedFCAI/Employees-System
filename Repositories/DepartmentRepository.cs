using EmployeeManagement.Contexts;
using EmployeeManagement.Entities;
using EmployeeManagement.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<string> GetDepartmentsName()
        {
            return _context.Departments.Select(d => d.DepartmentName).ToList();
        }


        public Department FindDepartmentByName(string name)
        {
            return _context.Departments.FirstOrDefault(d => d.DepartmentName == name);
        }

        public List<Employee> FindEmployeeByDepartment(int departmentId) 
        {
            return _context.Employees.Include(e => e.Department).Where(d => d.DepartmentId == departmentId).ToList();
        }

    }
}
