using EmployeeManagement.Entities;

namespace EmployeeManagement.Interfaces
{
    public interface IDepartmentRepository
    {
        public List<string> GetDepartmentsName();
        public Department FindDepartmentByName(string name);
        public List<Employee> FindEmployeeByDepartment(int departmentId);
    }
}
