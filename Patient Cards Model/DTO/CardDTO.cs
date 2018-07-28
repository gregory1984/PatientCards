using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.DTO
{
    public class CardDTO
    {
        public int Id { get; set; }
        public string Comments { get; set; }

        public virtual int PersonalInterviewId { get; set; }
        public virtual int? OtherInterviewId { get; set; }
        public virtual int? MedicamentInterviewId { get; set; }
        public virtual int? IllnessInterviewId { get; set; }
        public virtual int? ComplaintInterviewId { get; set; }

        public virtual int? GLCurrentCorrectionInterviewId { get; set; }
        public virtual int? CLCurrentCorrectionInterviewId { get; set; }
        public virtual int? GLSharpnessInterviewId { get; set; }
        public virtual int? GLMatchedCorrectionInterviewId { get; set; }
        public virtual int? CLFrontEyeSectionRateInterviewId { get; set; }
        public virtual int? CLSharpnessInterviewId { get; set; }
        public virtual int? CLMatchedCorrectionRateInterviewId { get; set; }
        public virtual int? CLMatchedCorrectionInterviewId { get; set; }

        public CardDTO() { }

        public CardDTO(
            int id, string comments, int personalInterviewId, int? otherInterviewId, int? medicamentInterviewId,
            int? illnessInterviewId, int? complaintInterviewId, int? gLCurrentCorrectionInterviewId,
            int? cLCurrentCorrectionInterviewId, int? gLSharpnessInterviewId, int? gLMatchedCorrectionInterviewId,
            int? cLFrontEyeSectionRateInterviewId, int? cLSharpnessInterviewId, int? cLMatchedCorrectionRateInterviewId, int? cLMatchedCorrectionInterviewId)
        {
            Id = id;
            Comments = comments;
            PersonalInterviewId = personalInterviewId;
            OtherInterviewId = otherInterviewId;
            MedicamentInterviewId = medicamentInterviewId;
            IllnessInterviewId = illnessInterviewId;
            ComplaintInterviewId = complaintInterviewId;
            GLCurrentCorrectionInterviewId = gLCurrentCorrectionInterviewId;
            CLCurrentCorrectionInterviewId = cLCurrentCorrectionInterviewId;
            GLSharpnessInterviewId = gLSharpnessInterviewId;
            GLMatchedCorrectionInterviewId = gLMatchedCorrectionInterviewId;
            CLFrontEyeSectionRateInterviewId = cLFrontEyeSectionRateInterviewId;
            CLSharpnessInterviewId = cLSharpnessInterviewId;
            CLMatchedCorrectionRateInterviewId = cLMatchedCorrectionRateInterviewId;
            CLMatchedCorrectionInterviewId = cLMatchedCorrectionInterviewId;
        }
    }
}
