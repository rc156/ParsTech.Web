using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParsTech.Data;
using ParsTech.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParsTech.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        //constructor
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.employee.ToListAsync());
        }


        // GET: Employee/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Employee());
            else
                return View(_context.employee.Find(id));
        }

        // POST: Employee/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("IDEmployee,EmployeeName")] Employee employees)
        {
            if (ModelState.IsValid)
            {
                if (employees.IDEmployee == 0)
                    _context.Add(employees);
                else
                    _context.Update(employees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employees);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var emp= await _context.employee.FindAsync(id);
            _context.employee.Remove(emp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
