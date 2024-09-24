using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Contexts;
using EmployeeManagement.Entities;
using EmployeeManagement.Interfaces;

namespace EmployeeManagement.Controllers
{
    public class ShiftController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public ShiftController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Shift

        public IActionResult Index(string searchTerm)
        {
            //var shifts = _context.Shifts.ToList();
            var shifts = _unitOfWork.ShiftRepository.GetAll();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                shifts = shifts.Where(e =>
                    e.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(shifts);
        }

        // GET: Shift/Details/5
        public async Task<IActionResult> Details(int id)
        {

           var shift = _unitOfWork.ShiftRepository.GetById(id);

            if (shift == null)
            {
                return NotFound();
            }

            return View(shift);
        }

        // GET: Shift/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shift/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StartTime,EndTime")] Shift shift)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ShiftRepository.Add(shift);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(shift);
        }

        // GET: Shift/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var shift = _unitOfWork.ShiftRepository.GetById(id);

            
            if (shift == null)
            {
                return NotFound();
            }
            return View(shift);
        }

        // POST: Shift/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StartTime,EndTime")] Shift shift)
        {
            if (id != shift.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(shift);
        }


        // GET: Shift/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var shift = _unitOfWork.ShiftRepository.GetById(id);
            if (shift != null)
            {
                _unitOfWork.ShiftRepository.SetNull(id);
                _unitOfWork.ShiftRepository.Delete(shift.Id);
                _unitOfWork.Save();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
