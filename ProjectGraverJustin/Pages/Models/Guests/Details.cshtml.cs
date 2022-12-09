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
    public class DetailsModel : PageModel
    {
        private readonly ProjectGraverJustin.JGraver1Context _context;

        public DetailsModel(ProjectGraverJustin.JGraver1Context context)
        {
            _context = context;
        }

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
    }
}
