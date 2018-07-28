using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.Entities.GL
{
    public class GLMatchedCorrection
    {
        public virtual int Id { get; set; }
        public virtual decimal Sphere { get; set; }
        public virtual decimal Cylinder { get; set; }
        public virtual int Axis { get; set; }
        public virtual decimal Addition { get; set; }
        public virtual decimal Prism { get; set; }
        public virtual Base Base { get; set; }
        public virtual Eye Eye { get; set; }
        public virtual GLMatchedCorrectionType GLMatchedCorrectionType { get; set; }
        public virtual GLMatchedCorrectionInterview GLMatchedCorrectionInterview { get; set; }
    }
}
