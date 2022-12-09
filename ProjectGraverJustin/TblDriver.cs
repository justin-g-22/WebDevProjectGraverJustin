using System;
using System.Collections.Generic;

namespace ProjectGraverJustin
{
    public partial class TblDriver
    {
        public TblDriver()
        {
            TblIncident = new HashSet<TblIncident>();
        }

        public short DriverId { get; set; }
        public string Dname { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string DState { get; set; }
        public string Zip { get; set; }

        public virtual ICollection<TblIncident> TblIncident { get; set; }
    }
}
