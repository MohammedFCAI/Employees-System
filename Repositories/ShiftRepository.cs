using EmployeeManagement.Contexts;
using EmployeeManagement.Entities;
using EmployeeManagement.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories
{
    public class ShiftRepository : GenericRepository<Shift>, IShiftRepository
    {
        private readonly ApplicationDbContext _context;

        public ShiftRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public Shift FindShiftByName(string name)
        {
            return _context.Shifts.FirstOrDefault(d => d.Name == name);
        }

        public List<string> GetShiftsName()
        {
            return _context.Shifts.Select(d => d.Name).ToList();
        }

        public List<Shift> GetShiftsIdAndName()
        {
            // Return a list of shifts
            return _context.Shifts.Select(s => new Shift { Id = s.Id, Name = s.Name }).ToList();
        }


        public void SetNull(int shiftId)
        {

            var employeesInShift = _context.Employees.Where(e => e.ShiftId == shiftId).ToList();

            foreach(var emp in employeesInShift)
            {
                emp.Shift = null;
                emp.ShiftId = null;
            }

        }
    }
}
