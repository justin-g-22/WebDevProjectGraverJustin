using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Jgraver1;

namespace ProjectGraverJustin.Pages.Models.ViewsandCharts
{
    public class ViewpatientsexModel : PageModel
    {
        private readonly ProjectGraverJustin.JGraver1Context _context;

        public ViewpatientsexModel(ProjectGraverJustin.JGraver1Context context)
        {
            _context = context;
        }

        public IList<Viewpatientsex> viewpatientsex { get; set; }


        public async Task OnGetAsync()
        {
            viewpatientsex = await _context.Viewpatientsex.FromSqlRaw("SELECT * FROM dbo.viewpatientsex").ToListAsync();


        }





    }
}