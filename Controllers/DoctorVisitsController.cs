using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicInfo.Data;
using ClinicInfo.Models;

namespace ClinicInfo.Controllers
{
    public class DoctorVisitsController : Controller
    {
        private readonly ClinicContext _context;

        public DoctorVisitsController(ClinicContext context)
        {
            _context = context;
        }

        // GET: DoctorVisits
        public async Task<IActionResult> Index()
        {
            var clinicContext = _context.DoctorVisit.Include(d => d.Doctor);
            return View(await clinicContext.ToListAsync());
        }

        // GET: DoctorVisits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DoctorVisit == null)
            {
                return NotFound();
            }

            var doctorVisit = await _context.DoctorVisit
                .Include(d => d.Doctor)
                .FirstOrDefaultAsync(m => m.DoctorVisitID == id);
            if (doctorVisit == null)
            {
                return NotFound();
            }

            return View(doctorVisit);
        }

        // GET: DoctorVisits/Create
        public IActionResult Create()
        {
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "DoctorID", "FullName");
            return View();
        }

        // POST: DoctorVisits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorVisitID,DoctorID,Date,StartTime,EndTime")] DoctorVisit doctorVisit)
        {
            
                _context.Add(doctorVisit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "DoctorID", "FullName", doctorVisit.DoctorID);
            return View(doctorVisit);
        }

        // GET: DoctorVisits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DoctorVisit == null)
            {
                return NotFound();
            }

            var doctorVisit = await _context.DoctorVisit.FindAsync(id);
            if (doctorVisit == null)
            {
                return NotFound();
            }
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "DoctorID", "FullName", doctorVisit.DoctorID);
            return View(doctorVisit);
        }

        // POST: DoctorVisits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoctorVisitID,DoctorID,Date,StartTime,EndTime")] DoctorVisit doctorVisit)
        {
            if (id != doctorVisit.DoctorVisitID)
            {
                return NotFound();
            }
            

         
                    _context.Update(doctorVisit);
                    await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "DoctorID", "FullName", doctorVisit.DoctorID);
            return View(doctorVisit);
        }

        // GET: DoctorVisits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DoctorVisit == null)
            {
                return NotFound();
            }

            var doctorVisit = await _context.DoctorVisit
                .Include(d => d.Doctor)
                .FirstOrDefaultAsync(m => m.DoctorVisitID == id);
            if (doctorVisit == null)
            {
                return NotFound();
            }

            return View(doctorVisit);
        }

        // POST: DoctorVisits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DoctorVisit == null)
            {
                return Problem("Entity set 'ClinicContext.DoctorVisit'  is null.");
            }
            var doctorVisit = await _context.DoctorVisit.FindAsync(id);
            if (doctorVisit != null)
            {
                _context.DoctorVisit.Remove(doctorVisit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorVisitExists(int id)
        {
          return (_context.DoctorVisit?.Any(e => e.DoctorVisitID == id)).GetValueOrDefault();
        }
    }
}
