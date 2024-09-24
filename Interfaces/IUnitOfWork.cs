using EmployeeManagement.Entities;

namespace EmployeeManagement.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Employee> Employees { get; }
        IGenericRepository<Department> Departments { get; }
        IGenericRepository<Payroll> Payrolls { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IShiftRepository ShiftRepository { get; }
        void Save();
    }

}
