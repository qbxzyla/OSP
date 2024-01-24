using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OSP.Data;
using OSP.Models;

namespace OSP.Controllers
{
    public class DrivesController : Controller
    {
        private readonly OSPContext _context;

        public DrivesController(OSPContext context)
        {
            _context = context;
        }

        // GET: Drives
        public async Task<IActionResult> Index()
        {
            var oSPContext = _context.Drive.Include(d => d.Firefighter).Include(d => d.Incident);
            return View(await oSPContext.ToListAsync());
        }

        // GET: Drives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Drive == null)
            {
                return NotFound();
            }

            var drive = await _context.Drive
                .Include(d => d.Firefighter)
                .Include(d => d.Incident)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drive == null)
            {
                return NotFound();
            }

            return View(drive);
        }

        // GET: Drives/Create
        public IActionResult Create()
        {
            ViewData["FirefighterId"] = new SelectList(_context.Firefighter, "Id", "Name");
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "Discription");
            return View();
        }

        // POST: Drives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirefighterId,IncidentId")] Drive drive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FirefighterId"] = new SelectList(_context.Firefighter, "Id", "Name", drive.FirefighterId);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "Discription", drive.IncidentId);
            return View(drive);
        }

        // GET: Drives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Drive == null)
            {
                return NotFound();
            }

            var drive = await _context.Drive.FindAsync(id);
            if (drive == null)
            {
                return NotFound();
            }
            ViewData["FirefighterId"] = new SelectList(_context.Firefighter, "Id", "Name", drive.FirefighterId);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "Discription", drive.IncidentId);
            return View(drive);
        }

        // POST: Drives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirefighterId,IncidentId")] Drive drive)
        {
            if (id != drive.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriveExists(drive.Id))
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
            ViewData["FirefighterId"] = new SelectList(_context.Firefighter, "Id", "Name", drive.FirefighterId);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "Discription", drive.IncidentId);
            return View(drive);
        }

        // GET: Drives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Drive == null)
            {
                return NotFound();
            }

            var drive = await _context.Drive
                .Include(d => d.Firefighter)
                .Include(d => d.Incident)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drive == null)
            {
                return NotFound();
            }

            return View(drive);
        }

        // POST: Drives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Drive == null)
            {
                return Problem("Entity set 'OSPContext.Drive'  is null.");
            }
            var drive = await _context.Drive.FindAsync(id);
            if (drive != null)
            {
                _context.Drive.Remove(drive);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriveExists(int id)
        {
          return (_context.Drive?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
