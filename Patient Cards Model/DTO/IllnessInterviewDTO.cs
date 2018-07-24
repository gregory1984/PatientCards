using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.DTO
{
    public class IllnessInterviewDTO
    {
        public int? Id { get; set; }
        public string Optionals { get; set; }
        public IList<IllnessDTO> Illnesses { get; set; }

        public IllnessInterviewDTO() { }

        public IllnessInterviewDTO(int? id, string optionals, IList<IllnessDTO> illnesses)
        {
            Id = id;
            Optionals = optionals;
            Illnesses = illnesses;
        }
    }
}
