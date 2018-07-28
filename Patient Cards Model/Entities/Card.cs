using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Cards_Model.Entities.CL;
using Patient_Cards_Model.Entities.GL;

namespace Patient_Cards_Model.Entities
{
    public class Card
    {
        public virtual int Id { get; set; }
        public virtual string Comments { get; set; }

        public virtual PersonalInterview PersonalInterview { get; set; }
        public virtual OtherInterview OtherInterview { get; set; }
        public virtual MedicamentInterview MedicamentInterview { get; set; }
        public virtual IllnessInterview IllnessInterview { get; set; }
        public virtual ComplaintInterview ComplaintInterview { get; set; }

        public virtual GLCurrentCorrectionInterview GLCurrentCorrectionInterview { get; set; }
        public virtual CLCurrentCorrectionInterview CLCurrentCorrectionInterview { get; set; }
        public virtual GLSharpnessInterview GLSharpnessInterview { get; set; }
        public virtual GLMatchedCorrectionInterview GLMatchedCorrectionInterview { get; set; }
        public virtual CLFrontEyeSectionRateInterview CLFrontEyeSectionRateInterview { get; set; }
        public virtual CLSharpnessInterview CLSharpnessInterview { get; set; }
        public virtual CLMatchedCorrectionRateInterview CLMatchedCorrectionRateInterview { get; set; }
        public virtual CLMatchedCorrectionInterview CLMatchedCorrectionInterview { get; set; }
    }
}
