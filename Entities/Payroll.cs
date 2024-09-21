namespace EmployeeManagement.Entities
{
    public class Payroll
    {
        public int PayrollId { get; set; }              
        public int EmployeeId { get; set; }             
        public Employee Employee { get; set; }          
        public decimal BasicSalary { get; set; }        
        public decimal Allowances { get; set; }         
        public decimal Deductions { get; set; }         
        public decimal NetSalary { get; set; }          
        public DateTime PaymentDate { get; set; }       
    }

}
