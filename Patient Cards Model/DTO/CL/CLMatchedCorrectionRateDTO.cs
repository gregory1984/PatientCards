using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.DTO.CL
{
    public class CLMatchedCorrectionRateDTO
    {
        public int? Id { get; set; }
        public string CurrentVisitRate { get; set; }
        public string ControlVisitRate { get; set; }
        public int? CardId { get; set; }
        public int CLMatchedCorrectionRateId { get; set; }
        public string CLMatchedCorrectionRateName { get; set; }

        public CLMatchedCorrectionRateDTO() { }

        public CLMatchedCorrectionRateDTO(int? id, string currentVisitRate, string controlVisitRate, int? cardId, int cLMatchedCorrectionRateId, string cLMatchedCorrectionRateName)
        {
            Id = id;
            CurrentVisitRate = currentVisitRate;
            ControlVisitRate = controlVisitRate;
            CardId = cardId;
            CLMatchedCorrectionRateId = cLMatchedCorrectionRateId;
            CLMatchedCorrectionRateName = cLMatchedCorrectionRateName;
        }
    }
}
