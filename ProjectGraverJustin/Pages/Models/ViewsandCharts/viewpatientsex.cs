using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using JGraver1;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


namespace Jgraver1
{
    public partial class Viewpatientsex
    {
        [Display(Name = "Sex")]
        public string Sex { get; set; }
        [Display(Name = "First Name")]
        public string firstname { get; set; }
    }
}