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
    public class DetailsModel : PageModel
    {
        private readonly ProjectGraverJustin.JGraver1Context _context;

        public DetailsModel(ProjectGraverJustin.JGraver1Context context)
        {
            _context = context;
        }

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
    }
}
