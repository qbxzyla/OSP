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
    public class CarInActionsController : Controller
    {
        private readonly OSPContext _context;

        public CarInActionsController(OSPContext context)
        {
            _context = context;
        }

        // GET: CarInActions
        public async Task<IActionResult> Index()
        {
            var oSPContext = _context.CarInAction.Include(c => c.Car).Include(c => c.Incident);
            return View(await oSPContext.ToListAsync());
        }

        // GET: CarInActions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarInAction == null)
            {
                return NotFound();
            }

            var carInAction = await _context.CarInAction
                .Include(c => c.Car)
                .Include(c => c.Incident)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carInAction == null)
            {
                return NotFound();
            }

            return View(carInAction);
        }

        // GET: CarInActions/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Model");
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "Discription");
            return View();
        }

        // POST: CarInActions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IncidentId,CarId")] CarInAction carInAction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carInAction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Model", carInAction.CarId);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "Discription", carInAction.IncidentId);
            return View(carInAction);
        }

        // GET: CarInActions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarInAction == null)
            {
                return NotFound();
            }

            var carInAction = await _context.CarInAction.FindAsync(id);
            if (carInAction == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Model", carInAction.CarId);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "Discription", carInAction.IncidentId);
            return View(carInAction);
        }

        // POST: CarInActions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IncidentId,CarId")] CarInAction carInAction)
        {
            if (id != carInAction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carInAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarInActionExists(carInAction.Id))
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
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Model", carInAction.CarId);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "Discription", carInAction.IncidentId);
            return View(carInAction);
        }

        // GET: CarInActions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarInAction == null)
            {
                return NotFound();
            }

            var carInAction = await _context.CarInAction
                .Include(c => c.Car)
                .Include(c => c.Incident)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carInAction == null)
            {
                return NotFound();
            }

            return View(carInAction);
        }

        // POST: CarInActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarInAction == null)
            {
                return Problem("Entity set 'OSPContext.CarInAction'  is null.");
            }
            var carInAction = await _context.CarInAction.FindAsync(id);
            if (carInAction != null)
            {
                _context.CarInAction.Remove(carInAction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarInActionExists(int id)
        {
          return (_context.CarInAction?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
