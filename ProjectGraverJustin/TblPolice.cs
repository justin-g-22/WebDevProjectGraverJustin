using System;
using System.Collections.Generic;

namespace ProjectGraverJustin
{
    public partial class TblPolice
    {
        public TblPolice()
        {
            TblIncident = new HashSet<TblIncident>();
        }

        public short PoliceId { get; set; }
        public string Pname { get; set; }

        public virtual ICollection<TblIncident> TblIncident { get; set; }
    }
}
