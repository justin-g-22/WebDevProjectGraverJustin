using System;
using System.Collections.Generic;

namespace ProjectGraverJustin
{
    public partial class TblPet
    {
        public TblPet()
        {
            TblAdoption = new HashSet<TblAdoption>();
        }

        public short PetId { get; set; }
        public string PetName { get; set; }
        public string PetType { get; set; }
        public string Breed { get; set; }
        public string Sex { get; set; }
        public DateTime Dob { get; set; }
        public short Price { get; set; }
        public string PetNotes { get; set; }

        public virtual ICollection<TblAdoption> TblAdoption { get; set; }
    }
}
