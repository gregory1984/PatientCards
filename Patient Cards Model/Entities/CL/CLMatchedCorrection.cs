using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.Entities.CL
{
    public class CLMatchedCorrection
    {
        public virtual int Id { get; set; }
        public virtual decimal Sphere { get; set; }
        public virtual decimal Cylinder { get; set; }
        public virtual decimal Axis { get; set; }
        public virtual decimal Addition { get; set; }
        public virtual decimal BC { get; set; }
        public virtual decimal DIA { get; set; }
        public virtual Eye Eye { get; set; }
        public virtual Card Card { get; set; }
        public virtual CLMatchedCorrectionType CLMatchedCorrectionType { get; set; }
    }
}
