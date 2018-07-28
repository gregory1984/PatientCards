using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.Entities.CL
{
    public class CLMatchedCorrectionRate
    {
        public virtual int Id { get; set; }
        public virtual string CurrentVisitRate { get; set; }
        public virtual string ControlVisitRate { get; set; }
        public virtual CLMatchedCorrectionRateInterview CLMatchedCorrectionRateInterview { get; set; }
        public virtual CLMatchedCorrectionRateIssue CLMatchedCorrectionRateIssue { get; set; }
    }
}
