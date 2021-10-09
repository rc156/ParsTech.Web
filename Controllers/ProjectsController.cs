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
    public class ProjectsController : Controller
    {

        private readonly ApplicationDbContext  _context;
        //constructor
        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.projects.ToListAsync());
        }


        // GET: Projects/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Projects());
            else
                return View(_context.projects.Find(id));
        }

        // POST: Projects/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("IdProject,ProjectName,StartDate,EndDate")] Projects projects)
        {
            if (ModelState.IsValid)
            {
                if (projects.IdProject == 0)
                    _context.Add(projects);
                else
                    _context.Update(projects);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projects);
        }

        // GET: Project/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var project = await _context.projects.FindAsync(id);
            _context.projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }




}
