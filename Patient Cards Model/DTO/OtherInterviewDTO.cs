using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.DTO
{
    public class OtherInterviewDTO
    {
        public int? Id { get; set; }
        public string OtherOptionals { get; set; }
        public IList<OtherDTO> OtherKinds { get; set; }

        public OtherInterviewDTO() { }

        public OtherInterviewDTO(int? id, string otherOptionals, IList<OtherDTO> otherKinds)
        {
            Id = id;
            OtherOptionals = otherOptionals;
            OtherKinds = otherKinds;
        }
    }
}
