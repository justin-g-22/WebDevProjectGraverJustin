using System;
using System.Collections.Generic;
using JGraver1;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ProjectGraverJustin
{
    public partial class TblPatient
    {
        public TblPatient()
        {
            TblAdmission = new HashSet<TblAdmission>();
        }

        public short PatientId { get; set; }
        [Display(Name = "Patient Last Name")]
        public string PatientLastName { get; set; }
        [Display(Name = "Patient First Name")]
        public string PatientFirstName { get; set; }
        public short PatientAge { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public DateTime DoB { get; set; }

        public virtual ICollection<TblAdmission> TblAdmission { get; set; }
    }
}
