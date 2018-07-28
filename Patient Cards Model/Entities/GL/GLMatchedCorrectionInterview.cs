using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.Entities.GL
{
    public class GLMatchedCorrectionInterview
    {
        public virtual int Id { get; set; }
        public virtual GLFinallyMatchedCorrectionType GLFinallyMatchedCorrectionType { get; set; }
        public virtual string GLFinallyMatchedCorrectionTypeOptionals { get; set; }
        public virtual IList<GLMatchedCorrection> GLMatchedCorrections { get; set; }
        public virtual IList<Card> Cards { get; set; }
    }
}
