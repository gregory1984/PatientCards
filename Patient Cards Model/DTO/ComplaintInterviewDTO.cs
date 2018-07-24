using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.DTO
{
    public class ComplaintInterviewDTO
    {
        public int? Id { get; set; }
        public string Optionals { get; set; }
        public IList<ComplaintDTO> Complaints { get; set; }

        public ComplaintInterviewDTO() { }

        public ComplaintInterviewDTO(int? id, string optionals, IList<ComplaintDTO> complaints)
        {
            Id = id;
            Optionals = optionals;
            Complaints = complaints;
        }
    }
}
