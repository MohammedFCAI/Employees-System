using EmployeeManagement.Entities;

namespace EmployeeManagement.Interfaces
{
    public interface IShiftRepository: IGenericRepository<Shift>
    {
        public List<string> GetShiftsName();
        public Shift FindShiftByName(string name);
        public List<Shift> GetShiftsIdAndName();
        public void SetNull(int shiftId);
    }
}
