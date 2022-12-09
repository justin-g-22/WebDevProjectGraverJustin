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
    public class DeleteModel : PageModel
    {
        private readonly ProjectGraverJustin.JGraver1Context _context;

        public DeleteModel(ProjectGraverJustin.JGraver1Context context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblStaff = await _context.TblStaff.FindAsync(id);

            if (TblStaff != null)
            {
                _context.TblStaff.Remove(TblStaff);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
