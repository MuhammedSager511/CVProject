using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class AddProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AddProjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddProject.ToListAsync());
        }

        // GET: AddProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addProject = await _context.AddProject
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addProject == null)
            {
                return NotFound();
            }

            return View(addProject);
        }

        // GET: AddProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectName,ProjectDesicrption")] AddProject addProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addProject);
        }

        // GET: AddProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addProject = await _context.AddProject.FindAsync(id);
            if (addProject == null)
            {
                return NotFound();
            }
            return View(addProject);
        }

        // POST: AddProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectName,ProjectDesicrption")] AddProject addProject)
        {
            if (id != addProject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddProjectExists(addProject.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(addProject);
        }

        // GET: AddProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addProject = await _context.AddProject
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addProject == null)
            {
                return NotFound();
            }

            return View(addProject);
        }

        // POST: AddProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addProject = await _context.AddProject.FindAsync(id);
            if (addProject != null)
            {
                _context.AddProject.Remove(addProject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddProjectExists(int id)
        {
            return _context.AddProject.Any(e => e.Id == id);
        }
    }
}
