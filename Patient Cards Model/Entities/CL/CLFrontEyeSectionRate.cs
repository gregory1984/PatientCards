using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.Entities.CL
{
    public class CLFrontEyeSectionRate
    {
        public virtual int Id { get; set; }
        public virtual string CurrentVisitRate { get; set; }
        public virtual string ControlVisitRate { get; set; }
        public virtual Card Card { get; set; }
        public virtual CLFrontEyeSectionRateIssue CLFrontEyeSectionRateIssue { get; set; }
    }
}
