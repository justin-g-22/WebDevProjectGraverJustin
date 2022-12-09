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
    public class IndexModel : PageModel
    {
        private readonly ProjectGraverJustin.JGraver1Context _context;

        public IndexModel(ProjectGraverJustin.JGraver1Context context)
        {
            _context = context;
        }

        public IList<TblAdmission> TblAdmission { get;set; }

        public async Task OnGetAsync()
        {
            TblAdmission = await _context.TblAdmission
                .Include(t => t.Guest)
                .Include(t => t.Patient)
                .Include(t => t.Staff).ToListAsync();
        }
    }
}
