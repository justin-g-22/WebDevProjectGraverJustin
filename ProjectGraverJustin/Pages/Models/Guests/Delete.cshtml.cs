using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectGraverJustin;

namespace ProjectGraverJustin.Pages.Models.Guests
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectGraverJustin.JGraver1Context _context;

        public DeleteModel(ProjectGraverJustin.JGraver1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblGuest TblGuest { get; set; }

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblGuest = await _context.TblGuest.FirstOrDefaultAsync(m => m.GuestId == id);

            if (TblGuest == null)
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

            TblGuest = await _context.TblGuest.FindAsync(id);

            if (TblGuest != null)
            {
                _context.TblGuest.Remove(TblGuest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
