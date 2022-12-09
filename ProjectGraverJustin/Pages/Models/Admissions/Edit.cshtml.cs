using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectGraverJustin;

namespace ProjectGraverJustin.Pages.Models.Admissions
{
    public class EditModel : PageModel
    {
        private readonly ProjectGraverJustin.JGraver1Context _context;

        public EditModel(ProjectGraverJustin.JGraver1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblAdmission TblAdmission { get; set; }

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblAdmission = await _context.TblAdmission
                .Include(t => t.Guest)
                .Include(t => t.Patient)
                .Include(t => t.Staff).FirstOrDefaultAsync(m => m.AdmissionId == id);

            if (TblAdmission == null)
            {
                return NotFound();
            }
           ViewData["GuestId"] = new SelectList(_context.TblGuest, "GuestId", "GuestFirstName");
           ViewData["PatientId"] = new SelectList(_context.TblPatient, "PatientId", "Address");
           ViewData["StaffId"] = new SelectList(_context.TblStaff, "StaffId", "Occupation");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TblAdmission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAdmissionExists(TblAdmission.AdmissionId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TblAdmissionExists(short id)
        {
            return _context.TblAdmission.Any(e => e.AdmissionId == id);
        }
    }
}
