using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using JGraver1;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace JGraver1
{
    public partial class avgStaffSalary1
    {
        [Display(Name = "Occupation")]
        public string Occupation { get; set; }
        [Display(Name = "Average Salary")]
        public long AverageSalary { get; set; }
    }
}