using System;
using System.Collections.Generic;

namespace ProjectGraverJustin
{
    public partial class TblOwner
    {
        public TblOwner()
        {
            TblAdoption = new HashSet<TblAdoption>();
        }

        public short OwnerId { get; set; }
        public string OwnerLastName { get; set; }
        public string OwnerFirstName { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<TblAdoption> TblAdoption { get; set; }
    }
}
