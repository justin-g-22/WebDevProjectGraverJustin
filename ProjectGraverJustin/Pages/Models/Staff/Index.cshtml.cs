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
    public class IndexModel : PageModel
    {
        private readonly ProjectGraverJustin.JGraver1Context _context;

        public IndexModel(ProjectGraverJustin.JGraver1Context context)
        {
            _context = context;
        }

        public IList<TblStaff> TblStaff { get;set; }

        public async Task OnGetAsync()
        {
            TblStaff = await _context.TblStaff.ToListAsync();
        }
    }
}
