using System;
using System.Collections.Generic;
using JGraver1;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ProjectGraverJustin
{
    public partial class TblStaff
    {
        public TblStaff()
        {
            TblAdmission = new HashSet<TblAdmission>();
        }

        public short StaffId { get; set; }
        [Display(Name = "Staff Last Name")]
        public string StaffNameLast { get; set; }
        [Display(Name = "Staff First Name")]
        public string StaffNameFirst { get; set; }
        public string Occupation { get; set; }
        public long Salary { get; set; }

        public virtual ICollection<TblAdmission> TblAdmission { get; set; }
    }
}
