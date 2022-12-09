using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectGraverJustin;

namespace ProjectGraverJustin.Pages.Models.Staff
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectGraverJustin.JGraver1Context _context;

        public DetailsModel(ProjectGraverJustin.JGraver1Context context)
        {
            _context = context;
        }

        public TblStaff TblStaff { get; set; }

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblStaff = await _context.TblStaff.FirstOrDefaultAsync(m => m.StaffId == id);

            if (TblStaff == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
