using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.Entities.CL
{
    public class CLMatchedCorrectionInterview
    {
        public virtual int Id { get; set; }
        public virtual CLWearingType CLWearingTypeTest { get; set; }
        public virtual CLPrimaryData CLPrimaryDataTest { get; set; }
        public virtual CLWearingType CLWearingTypeTrade { get; set; }
        public virtual CLPrimaryData CLPrimaryDataTrade { get; set; }
        public virtual IList<CLMatchedCorrection> CLMatchedCorrections { get; set; }
        public virtual IList<Card> Cards { get; set; }
    }
}
