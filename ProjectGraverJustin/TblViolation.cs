using System;
using System.Collections.Generic;

namespace ProjectGraverJustin
{
    public partial class TblViolation
    {
        public TblViolation()
        {
            TblIncident = new HashSet<TblIncident>();
        }

        public short ViolationId { get; set; }
        public string Violation { get; set; }
        public string Fine { get; set; }

        public virtual ICollection<TblIncident> TblIncident { get; set; }
    }
}
