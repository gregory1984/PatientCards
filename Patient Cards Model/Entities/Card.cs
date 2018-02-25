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
        public virtual DateTime CurrentVisitDate { get; set; }
        public virtual DateTime? PreviousVisitDate { get; set; }
        public virtual string ControlVisitDate { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual int PatientAge { get; set; }
        public virtual string VisitCause { get; set; }
        public virtual string ProfessionOrHobby { get; set; }
        public virtual Distance Distance { get; set; }
        public virtual bool IsComputerProfession { get; set; }
        public virtual string ComputerProfessionOptional { get; set; }
        public virtual bool IsCarDriving { get; set; }
        public virtual string CarDrivingOptional { get; set; }
        public virtual string Comments { get; set; }
        public virtual IList<CLProfessionCondition> CLProfessionConditions { get; set; }
        public virtual string CLProfessionConditionOptional { get; set; }
        public virtual string Treatments { get; set; }
        public virtual IList<Other> Others { get; set; }
        public virtual string OthersOptional { get; set; }
        public virtual IList<Medicament> Medicaments { get; set; }
        public virtual string MedicamentsOptional { get; set; }
        public virtual IList<Complaint> Complaints { get; set; }
        public virtual string ComplaintsOptional { get; set; }
        public virtual IList<Illness> Illnesses { get; set; }
        public virtual string IllnessesOptional { get; set; }
        public virtual string CurrentGLType { get; set; }
        public virtual IList<GLCurrentCorrection> GLCurrentCorrections { get; set; }
        public virtual string GLCurrentCorrectionFromWhen { get; set; }
        public virtual IList<CLCurrentCorrection> CLCurrentCorrections { get; set; }
        public virtual string CLCurrentCorrectionFromWhen { get; set; }
        public virtual CLWearingType CLWearingTypeCurrent { get; set; }
        public virtual IList<GLSharpness> GLSharpnesses { get; set; }
        public virtual IList<CLSharpness> CLSharpnesses { get; set; }
        public virtual IList<CLFrontEyeSectionRate> CLFrontEyeSectionRates { get; set; }
        public virtual GLFinallyMatchedCorrectionType GLFinallyMatchedCorrectionType { get; set; }
        public virtual string GLFinallyMatchedCorrectionTypeOptional { get; set; }
        public virtual IList<GLMatchedCorrection> GLMatchedCorrections { get; set; }
        public virtual CLWearingType CLWearingTypeMatchedTest { get; set; }
        public virtual CLWearingType CLWearingTypeMatchedTrade { get; set; }
        public virtual IList<CLPrimaryData> CLPrimaryDatas { get; set; }
        public virtual IList<CLMatchedCorrection> CLMatchedCorrections { get; set; }
        public virtual IList<CLMatchedCorrectionRate> CLMatchedCorrectionRates { get; set; }
    }
}
