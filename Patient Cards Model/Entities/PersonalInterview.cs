using Patient_Cards_Model.Entities.CL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.Entities
{
    public class PersonalInterview
    {
        public virtual int Id { get; set; }
        public virtual DateTime CurrentVisitDate { get; set; }
        public virtual DateTime? PreviousVisitDate { get; set; }
        public virtual string ControlVisitDate { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual string VisitCause { get; set; }
        public virtual string ProfessionOrHobby { get; set; }
        public virtual Distance Distance { get; set; }
        public virtual bool IsComputerProfession { get; set; }
        public virtual string ComputerProfessionOptionals { get; set; }
        public virtual bool IsCarDriving { get; set; }
        public virtual string CarDrivingOptionals { get; set; }
        public virtual CLProfessionCondition CLProfessionCondition { get; set; }
        public virtual string CLProfessionConditionOptionals { get; set; }
        public virtual string Treatments { get; set; }
        public virtual IList<Card> Cards { get; set; }
    }
}
