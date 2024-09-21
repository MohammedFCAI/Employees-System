using EmployeeManagement.Entities;
using EmployeeManagement.Interfaces;
using EmployeeManagement.Repositories;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string searchTerm)
        {
            var departments = _unitOfWork.Departments.GetAll();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                departments = departments.Where(e =>
                    e.DepartmentName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(departments);
        }

        public IActionResult Add()
        {
            return View(new DepartmentViewModel());
        }


        [HttpPost]
        public IActionResult Add(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department { DepartmentName = model.DepartmentName.ToUpper() };
                
                _unitOfWork.Departments.Add(department);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(model); 
        }


        public IActionResult Edit(int id)
        {
            var department = _unitOfWork.Departments.GetById(id);
            var departmentView = new DepartmentViewModel()
            {
                DepartmentName = department.DepartmentName,
            };
            return View(departmentView);
        }


        [HttpPost]
        public IActionResult Edit(DepartmentViewModel model, int id)
        {
            if (ModelState.IsValid)
            {
                var department = _unitOfWork.Departments.GetById(id);
                department.DepartmentName = model.DepartmentName.ToUpper();

                _unitOfWork.Departments.Update(department);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        public IActionResult Delete(int id) 
        {
            
            _unitOfWork.Departments.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult EmployeeByDepartment(int departmentId)
        {
            var employees = _unitOfWork.DepartmentRepository.FindEmployeeByDepartment(departmentId);

            return RedirectToAction(nameof(Index), nameof(Employee), employees);
        }
        

    }
}
