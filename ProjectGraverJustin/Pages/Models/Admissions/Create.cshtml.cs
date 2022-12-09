using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectGraverJustin;

namespace ProjectGraverJustin.Pages.Models.Admissions
{
    public class CreateModel : PageModel
    {
        private readonly ProjectGraverJustin.JGraver1Context _context;

        public CreateModel(ProjectGraverJustin.JGraver1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["GuestId"] = new SelectList(_context.TblGuest, "GuestId", "GuestFirstName");
        ViewData["PatientId"] = new SelectList(_context.TblPatient, "PatientId", "Address");
        ViewData["StaffId"] = new SelectList(_context.TblStaff, "StaffId", "Occupation");
            return Page();
        }

        [BindProperty]
        public TblAdmission TblAdmission { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblAdmission.Add(TblAdmission);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
