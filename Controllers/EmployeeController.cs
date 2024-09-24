using EmployeeManagement.Entities;
using EmployeeManagement.Interfaces;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index(string searchTerm)
        {
            var employees = _employeeRepository.GetAll();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                employees = employees.Where(e =>
                    (e.FirstName + " " + e.LastName).Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    e.Department.DepartmentName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(employees);
        }


        public IActionResult Add()
        {
            var departments = _unitOfWork.Departments.GetAll();
            var shifts = _unitOfWork.ShiftRepository.GetAll();
            return View(new EmployeeViewModel() { Departments = departments, Shifts = shifts});
        }


        [HttpPost]
        public IActionResult Add(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {

                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Status = model.Status,
                    Gender = model.Gender,
                    Department = _unitOfWork.Departments.GetById(model.DepartmentId),
                    Shift = _unitOfWork.ShiftRepository.GetById(model.ShiftId)
                };

                _unitOfWork.Employees.Add(employee);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }



        public IActionResult Details(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetByIdAsNoTracking(id);
            if(employee.Shift == null)
            {
                employee.Shift = new Shift();
            }

            if(employee != null)
            {
                return View(employee);
            }

            return RedirectToAction(nameof(Index));
        }



        public IActionResult Edit(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if(employee != null)
            {
                //ViewBag.Departments = new SelectList(_unitOfWork.Departments.GetAll(), "DepartmentId", "DepartmentName");

                ViewBag.Departments = _unitOfWork.DepartmentRepository.GetDepartmentsName();
                ViewBag.Shifts = _unitOfWork.ShiftRepository.GetShiftsName();
                //ViewBag.ShiftsIdName = _unitOfWork.ShiftRepository.GetShiftsIdAndName();
                ViewBag.ShiftsIdName = new SelectList(_unitOfWork.ShiftRepository.GetShiftsIdAndName(), "Id", "Name", employee.ShiftId);

                ViewBag.Gender = Enum.GetValues(typeof(Gender))
                   .Cast<Gender>()
                   .Select(e => e.ToString())
                   .ToList();

                ViewBag.Status  = Enum.GetValues(typeof(Status))
                   .Cast<Status>()
                   .Select(e => e.ToString())
                   .ToList();

                return View(employee);
            }
            return RedirectToAction(nameof(Index));
           
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                // Fetch the existing employee by ID
                var employee = _unitOfWork.EmployeeRepository.GetById(model.EmployeeId);
                if (employee == null)
                {
                    return NotFound();
                }

                var newDepartment = _unitOfWork.DepartmentRepository.FindDepartmentByName(model.Department.DepartmentName);
                //var newShift = _unitOfWork.ShiftRepository.FindShiftByName(model.Shift.Name);
                var newShift = _unitOfWork.ShiftRepository.GetById(model.ShiftId.Value);

                // Update the existing employee properties
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.DateOfBirth = model.DateOfBirth;
                employee.PhoneNumber = model.PhoneNumber;
                employee.Email = model.Email;
                employee.Status = model.Status;
                employee.Gender = model.Gender;
                employee.DepartmentId = newDepartment.DepartmentId; // Update DepartmentId
                employee.Department = newDepartment;
                employee.Shift = newShift;
                employee.ShiftId = newShift.Id;

                _unitOfWork.Employees.Update(employee);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _unitOfWork.Employees.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }



        



    }
}
