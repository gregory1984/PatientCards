using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.DTO
{
    public class DistanceDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public DistanceDTO() { }

        public DistanceDTO(int? id, string name)
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
