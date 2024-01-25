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
    public class CrewsController : Controller
    {
        private readonly OSPContext _context;

        public CrewsController(OSPContext context)
        {
            _context = context;
        }

        // GET: Crews
        public async Task<IActionResult> Index()
        {
            var oSPContext = _context.Crew.Include(c => c.Driver).Include(c => c.Incident);
            return View(await oSPContext.ToListAsync());
        }

        // GET: Crews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Crew == null)
            {
                return NotFound();
            }

            var crew = await _context.Crew
                .Include(c => c.Driver)
                .Include(c => c.Incident)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crew == null)
            {
                return NotFound();
            }

            return View(crew);
        }

        // GET: Crews/Create
        public IActionResult Create()
        {

            ViewData["DriverId"] = new SelectList(_context.Firefighter, "Id", "Surname");
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IN");
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Name");
            ViewData["FirefighterId"] = new SelectList(_context.Firefighter, "Id", "Name");

            return View();
        }

        // POST: Crews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataS,CarId,FirefighterId,DriverId,IncidentId")] Crew crew)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crew);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = new SelectList(_context.Firefighter, "Id", "Surname", crew.DriverId);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IN", crew.IncidentId);
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Name",crew.CarId);
            ViewData["FirefighterId"] = new SelectList(_context.Firefighter, "Id", "Surname", crew.FirefighterId);
            return View(crew);
        }

        // GET: Crews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Crew == null)
            {
                return NotFound();
            }

            var crew = await _context.Crew.FindAsync(id);
            if (crew == null)
            {
                return NotFound();
            }
            ViewData["DriverId"] = new SelectList(_context.Firefighter, "Id", "Name", crew.DriverId);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "Discription", crew.IncidentId);
            return View(crew);
        }

        // POST: Crews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataS,CarId,FirefighterId,DriverId,IncidentId")] Crew crew)
        {
            if (id != crew.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crew);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CrewExists(crew.Id))
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
            ViewData["DriverId"] = new SelectList(_context.Firefighter, "Id", "Name", crew.DriverId);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "Discription", crew.IncidentId);
            return View(crew);
        }

        // GET: Crews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Crew == null)
            {
                return NotFound();
            }

            var crew = await _context.Crew
                .Include(c => c.Driver)
                .Include(c => c.Incident)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crew == null)
            {
                return NotFound();
            }

            return View(crew);
        }

        // POST: Crews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Crew == null)
            {
                return Problem("Entity set 'OSPContext.Crew'  is null.");
            }
            var crew = await _context.Crew.FindAsync(id);
            if (crew != null)
            {
                _context.Crew.Remove(crew);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CrewExists(int id)
        {
          return (_context.Crew?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
