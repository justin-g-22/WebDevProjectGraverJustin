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
    public class DetailsModel : PageModel
    {
        private readonly ProjectGraverJustin.JGraver1Context _context;

        public DetailsModel(ProjectGraverJustin.JGraver1Context context)
        {
            _context = context;
        }

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
    }
}
