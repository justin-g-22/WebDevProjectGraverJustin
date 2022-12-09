using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectGraverJustin;

namespace ProjectGraverJustin.Pages.Models.Admissions
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectGraverJustin.JGraver1Context _context;

        public DeleteModel(ProjectGraverJustin.JGraver1Context context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblAdmission = await _context.TblAdmission.FindAsync(id);

            if (TblAdmission != null)
            {
                _context.TblAdmission.Remove(TblAdmission);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
