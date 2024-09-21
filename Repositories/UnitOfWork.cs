using EmployeeManagement.Contexts;
using EmployeeManagement.Entities;
using EmployeeManagement.Interfaces;

namespace EmployeeManagement.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Employees = new GenericRepository<Employee>(context);
            Departments = new GenericRepository<Department>(context);
            Payrolls = new GenericRepository<Payroll>(context);
            DepartmentRepository = new DepartmentRepository(context);
            EmployeeRepository = new EmployeeRepository(context);
        }

        public IGenericRepository<Employee> Employees { get; private set; }
        public IGenericRepository<Department> Departments { get; private set; }
        public IGenericRepository<Payroll> Payrolls { get; private set; }
        public IDepartmentRepository DepartmentRepository { get; private set; }
        public IEmployeeRepository EmployeeRepository { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
