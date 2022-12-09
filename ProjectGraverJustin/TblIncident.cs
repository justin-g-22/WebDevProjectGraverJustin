using System;
using System.Collections.Generic;

namespace ProjectGraverJustin
{
    public partial class TblIncident
    {
        public string IncidentId { get; set; }
        public DateTime IncidentDate { get; set; }
        public short ViolationId { get; set; }
        public short PoliceId { get; set; }
        public short DriverId { get; set; }

        public virtual TblDriver Driver { get; set; }
        public virtual TblPolice Police { get; set; }
        public virtual TblViolation Violation { get; set; }
    }
}
