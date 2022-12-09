using System;
using System.Collections.Generic;
using JGraver1;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ProjectGraverJustin
{
    public partial class TblAdmission
    {
        public short AdmissionId { get; set; }
        public short PatientId { get; set; }
        public short StaffId { get; set; }
        public short? GuestId { get; set; }
        public DateTime TimeAdmitted { get; set; }
        public string Reason { get; set; }

        public virtual TblGuest Guest { get; set; }
        public virtual TblPatient Patient { get; set; }
        public virtual TblStaff Staff { get; set; }
    }
}
