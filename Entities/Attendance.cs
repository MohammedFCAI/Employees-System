namespace EmployeeManagement.Entities
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }

}
