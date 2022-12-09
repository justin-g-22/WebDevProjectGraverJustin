using System;
using System.Collections.Generic;

namespace ProjectGraverJustin
{
    public partial class TblAdoption
    {
        public short AdoptionId { get; set; }
        public short OwnerId { get; set; }
        public short PetId { get; set; }

        public virtual TblOwner Owner { get; set; }
        public virtual TblPet Pet { get; set; }
    }
}
