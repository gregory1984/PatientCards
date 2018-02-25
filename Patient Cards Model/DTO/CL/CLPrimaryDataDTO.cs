using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.DTO.CL
{
    public class CLPrimaryDataDTO
    {
        public int? Id { get; set; }
        public int? CardId { get; set; }
        public string Name { get; set; }
        public string Vendor { get; set; }
        public string Liquid { get; set; }
        public int CLMatchedCorrectionTypeId { get; set; }

        public CLPrimaryDataDTO() { }

        public CLPrimaryDataDTO(int? id, int? cardId, string name, string vendor, string liquid, int cLMatchedCorrectionTypeId)
        {
            Id = id;
            CardId = cardId;
            Name = name;
            Vendor = vendor;
            Liquid = liquid;
            CLMatchedCorrectionTypeId = cLMatchedCorrectionTypeId;
        }
    }
}
