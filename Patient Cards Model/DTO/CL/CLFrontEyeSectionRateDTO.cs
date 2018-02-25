using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.DTO.CL
{
    public class CLFrontEyeSectionRateDTO
    {
        public int? Id { get; set; }
        public string CurrentVisitRate { get; set; }
        public string ControlVisitRate { get; set; }
        public int? CardId { get; set; }
        public int CLFronEyeSectionIssueId { get; set; }
        public string CLFronEyeSectionIssueName { get; set; }

        public CLFrontEyeSectionRateDTO() { }

        public CLFrontEyeSectionRateDTO(int? id, string currentVisitRate, string controlVisitRate, int? cardId, int cLFronEyeSectionIssueId, string cLFronEyeSectionIssueName)
        {
            Id = id;
            CurrentVisitRate = currentVisitRate;
            ControlVisitRate = controlVisitRate;
            CardId = cardId;
            CLFronEyeSectionIssueId = cLFronEyeSectionIssueId;
            CLFronEyeSectionIssueName = cLFronEyeSectionIssueName;
        }
    }
}
