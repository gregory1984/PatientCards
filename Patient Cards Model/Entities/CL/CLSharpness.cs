using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.Entities.CL
{
    public class CLSharpness
    {
        public virtual int Id { get; set; }
        public virtual decimal CurrentCorrection { get; set; }
        public virtual decimal CC { get; set; }
        public virtual Card Card { get; set; }
        public virtual Eye Eye { get; set; }
    }
}
