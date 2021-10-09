using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParsTech.Data;
using ParsTech.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParsTech.Web.Controllers
{
    public class EmpProjectController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmpProjectController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult ViewProject(int id = 0)
        {
            if (id == 0)
            {
                ViewProjectVM viewProjectVM = new ViewProjectVM();
                viewProjectVM.ProjectName = _context.projects.Select(c => new SelectListItem() { Text = c.ProjectName, Value = c.IdProject.ToString() }).ToList();
                return View(viewProjectVM);
            }

            else
            {
                ViewProjectVM viewProjectVM = new ViewProjectVM();
                viewProjectVM.IdEmployee = id;
                viewProjectVM.ProjectName = _context.projects.Select(c => new SelectListItem() { Text = c.ProjectName, Value = c.IdProject.ToString() }).ToList();
                return View(viewProjectVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignProject(ViewProjectVM viewProjectVM)
        {
            if (ModelState.IsValid)
            {

                EmployeeProject empProject = new EmployeeProject();
                empProject.IdEmployee = viewProjectVM.IdEmployee;
                empProject.IdProject = viewProjectVM.IdProject;
                if (viewProjectVM.IdEmployee == 0)
                {
                    _context.Add(empProject);
                }
                else
                    _context.Update(empProject);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Employee");
            }
            return View(viewProjectVM);
        }
        public IActionResult EmpProjList(int id = 0)
        {
            List<ProjectNames> ProjectNames = new List<ProjectNames>();
            ProjectNames = (from ep in _context.employeeProject
                          join p in _context.projects on ep.IdProject equals p.IdProject where ep.IdEmployee==id
                          select new ProjectNames { ProjectName=p.ProjectName}).ToList();

            return View(ProjectNames);
        }

       
    }
}
