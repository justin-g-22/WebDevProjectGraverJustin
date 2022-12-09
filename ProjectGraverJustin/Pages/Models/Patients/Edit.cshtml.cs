using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectGraverJustin;

namespace ProjectGraverJustin.Pages.Models.Patients
{
    public class EditModel : PageModel
    {
        private readonly ProjectGraverJustin.JGraver1Context _context;

        public EditModel(ProjectGraverJustin.JGraver1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblPatient TblPatient { get; set; }

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblPatient = await _context.TblPatient.FirstOrDefaultAsync(m => m.PatientId == id);

            if (TblPatient == null)
            {
                return NotFound();
            }
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

            _context.Attach(TblPatient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPatientExists(TblPatient.PatientId))
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

        private bool TblPatientExists(short id)
        {
            return _context.TblPatient.Any(e => e.PatientId == id);
        }
    }
}
