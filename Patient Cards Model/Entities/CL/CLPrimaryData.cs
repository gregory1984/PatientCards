using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.Entities.CL
{
    public class CLPrimaryData
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Vendor { get; set; }
        public virtual string Liquid { get; set; }
        public virtual Card Card { get; set; }
        public virtual CLMatchedCorrectionType CLMatchedCorrectionType { get; set; }
    }
}
