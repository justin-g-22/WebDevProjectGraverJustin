using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using JGraver1;
using Microsoft.Data.SqlClient;

namespace ProjectGraverJustin.Pages.Models.Views
{
    public class avgStaffSalary1Model : PageModel
    {
        private readonly ProjectGraverJustin.JGraver1Context _context;

        public avgStaffSalary1Model(ProjectGraverJustin.JGraver1Context context)
        {
            _context = context;
        }

        public IList<avgStaffSalary1> avgStaffSalary1 { get; set; }


        public async Task OnGetAsync()
        {
            avgStaffSalary1 = await _context.avgStaffSalary1.FromSqlRaw("SELECT * FROM dbo.avgStaffSalary1").ToListAsync();


        }





    }
}