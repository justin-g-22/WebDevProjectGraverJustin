using System;
using System.Collections.Generic;
using JGraver1;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ProjectGraverJustin
{
    public partial class TblGuest
    {
        public TblGuest()
        {
            TblAdmission = new HashSet<TblAdmission>();
        }

        public short GuestId { get; set; }

        [Display(Name = "Guest Last Name")]
        public string GuestLastName { get; set; }
        [Display(Name = "Guest First Name")]
        public string GuestFirstName { get; set; }
        public DateTime GuestDoB { get; set; }
        public DateTime GuestSignIn { get; set; }

        public virtual ICollection<TblAdmission> TblAdmission { get; set; }
    }
}
