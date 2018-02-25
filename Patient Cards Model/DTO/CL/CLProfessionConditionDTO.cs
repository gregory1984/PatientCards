using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.DTO.CL
{
    public class CLProfessionConditionDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public CLProfessionConditionDTO() { }

        public CLProfessionConditionDTO(int? id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
