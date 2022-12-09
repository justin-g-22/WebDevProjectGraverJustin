using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectGraverJustin;

namespace ProjectGraverJustin.Pages.Models.Patients
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectGraverJustin.JGraver1Context _context;

        public DeleteModel(ProjectGraverJustin.JGraver1Context context)
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

        public async Task<IActionResult> OnPostAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblPatient = await _context.TblPatient.FindAsync(id);

            if (TblPatient != null)
            {
                _context.TblPatient.Remove(TblPatient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
