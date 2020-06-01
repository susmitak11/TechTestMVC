using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechTestMVC.Areas.Identity.Data;
using TechTestMVC.Data;
using TechTestMVC.Models;

namespace TechTestMVC.Controllers
{
    public class AttendeesController : Controller
    {
        private readonly UserManager<TechTestMVCUser> _userManager;
        private readonly TechTestMVCDbContext _context;

        public AttendeesController(TechTestMVCDbContext context, UserManager<TechTestMVCUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize(Roles = "Admin,Staff")]
        // GET: Attendees
        public async Task<IActionResult> Index()
        {
            var techTestMVCDbContext = _context.Attendee.Include(a => a.Tech);
            return View(await techTestMVCDbContext.ToListAsync());
        }
        [Authorize(Roles = "Admin,Staff")]
        // GET: Attendees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendee = await _context.Attendee
                .Include(a => a.Tech)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendee == null)
            {
                return NotFound();
            }

            return View(attendee);
        }
        [Authorize(Roles = "Customer")]
        // GET: Attendees/Create
        public IActionResult Create()
        {
            ViewData["TechnologyId"] = new SelectList(_context.Technology, "Id", "Id");
            return View();
        }

        // POST: Attendees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Customer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TechnologyId,Date")] Attendee attendee)
        {
            attendee.User = _userManager.GetUserAsync(User).Result;

            if (ModelState.IsValid)
            {
                _context.Add(attendee);
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Success", "Home");
            }
            ViewData["TechnologyId"] = new SelectList(_context.Technology, "Id", "Id", attendee.TechnologyId);
            return View(attendee);
        }
        [Authorize(Roles = "Admin,Staff")]
        // GET: Attendees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendee = await _context.Attendee.FindAsync(id);
            if (attendee == null)
            {
                return NotFound();
            }
            ViewData["TechnologyId"] = new SelectList(_context.Technology, "Id", "Id", attendee.TechnologyId);
            return View(attendee);
        }
        [Authorize(Roles = "Admin,Staff")]
        // POST: Attendees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TechnologyId,Date")] Attendee attendee)
        {
            if (id != attendee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendeeExists(attendee.Id))
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
            ViewData["TechnologyId"] = new SelectList(_context.Technology, "Id", "Id", attendee.TechnologyId);
            return View("Home");
        }
        [Authorize(Roles = "Admin,Staff")]
        // GET: Attendees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendee = await _context.Attendee
                .Include(a => a.Tech)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendee == null)
            {
                return NotFound();
            }

            return View(attendee);
        }
        [Authorize(Roles = "Admin,Staff")]
        // POST: Attendees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendee = await _context.Attendee.FindAsync(id);
            _context.Attendee.Remove(attendee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendeeExists(int id)
        {
            return _context.Attendee.Any(e => e.Id == id);
        }
    }
}
