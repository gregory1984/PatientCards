using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.Entities.CL
{
    public class CLMatchedCorrectionType
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<CLMatchedCorrection> CLMatchedCorrections { get; set; }
        public virtual IList<CLPrimaryData> CLPrimaryDatas { get; set; }
    }
}
