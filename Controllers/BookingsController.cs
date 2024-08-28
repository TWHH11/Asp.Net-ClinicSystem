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
    public class BookingsController : Controller
    {
        private readonly ClinicContext _context;

        public BookingsController(ClinicContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var clinicContext = _context.Booking.Include(b => b.Doctor).Include(b => b.Patient);
            return View(await clinicContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Doctor)
                .Include(b => b.Patient)
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public async Task<IActionResult> Create(string BookingDate)
        {

            if (BookingDate != null)
            {
                DateTime dateValue = DateTime.Parse(BookingDate);
                

                var filteredVisits = _context.DoctorVisit
                                 .Include(visit => visit.Doctor)
                                 .Where(visit => visit.Date != null && visit.Date == dateValue)
                                 .ToList();


                var doctorVisits = filteredVisits

                       .Select(d => new SelectListItem
                       {
                           Value = d.DoctorID.ToString(),
                           Text = d.Doctor.FullName
                       })
                       .ToList();


                ViewData["Doctors"] = new SelectList(doctorVisits, "Value", "Text");

            }
            

            ViewData["Patients"] = new SelectList(_context.Patient, "PatientID", "FullName");

            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingID,PatientID,DoctorID,Date,Time")] Booking booking)
        {
           
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "DoctorID", "FullName", booking.Doctor);
            ViewData["PatientID"] = new SelectList(_context.Patient, "PatientID", "FullName", booking.PatientID);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id,string BookingDate)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            if (BookingDate != null)
            {
                DateTime dateValue = DateTime.Parse(BookingDate);


                var filteredVisits = _context.DoctorVisit
                                 .Include(visit => visit.Doctor)
                                 .Where(visit => visit.Date != null && visit.Date == dateValue)
                                 .ToList();


                var doctorVisits = filteredVisits

                       .Select(d => new SelectListItem
                       {
                           Value = d.DoctorID.ToString(),
                           Text = d.Doctor.FullName
                       })
                       .ToList();


                ViewData["Doctors"] = new SelectList(doctorVisits, "Value", "Text");

            }

            ViewData["PatientID"] = new SelectList(_context.Patient, "PatientID", "FullName", booking.PatientID);

            return View(booking);
        }


        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingID,PatientID,DoctorID,Date,Time")] Booking booking)
        {
            if (id != booking.BookingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingID))
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
            ViewData["DoctorVisitID"] = new SelectList(_context.DoctorVisit, "DoctorID", "DoctorID", booking.DoctorID);
            ViewData["PatientID"] = new SelectList(_context.Patient, "PatientID", "FullName", booking.PatientID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Doctor)
                .Include(b => b.Patient)
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Booking == null)
            {
                return Problem("Entity set 'ClinicContext.Booking'  is null.");
            }
            var booking = await _context.Booking.FindAsync(id);
            if (booking != null)
            {
                _context.Booking.Remove(booking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
          return (_context.Booking?.Any(e => e.BookingID == id)).GetValueOrDefault();
        }
    }
}
