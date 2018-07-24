using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.DTO
{
    public class MedicamentInterviewDTO
    {
        public int? Id { get; set; }
        public string MedicamentOptionals { get; set; }
        public IList<MedicamentDTO> MedicamentKinds { get; set; }

        public MedicamentInterviewDTO() { }

        public MedicamentInterviewDTO(int? id, string medicamentOptionals, IList<MedicamentDTO> medicamentKinds)
        {
            Id = id;
            MedicamentOptionals = medicamentOptionals;
            MedicamentKinds = medicamentKinds;
        }
    }
}
