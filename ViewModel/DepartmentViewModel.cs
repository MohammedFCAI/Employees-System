using EmployeeManagement.Validations;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModel
{
    public class DepartmentViewModel
    {
        [Required(ErrorMessage = "Department name is required!")]
        [Display(Name ="Department Name")]
        [UniqueName]
        public string DepartmentName { get; set; }
    }
}