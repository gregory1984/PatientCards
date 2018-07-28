using Patient_Cards_Model.Entities.GL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.Entities.GL
{
    public class GLCurrentCorrectionInterview
    {
        public virtual int Id { get; set; }
        public virtual string CurrentGLType { get; set; }
        public virtual string FromWhen { get; set; }
        public virtual IList<GLCurrentCorrection> GLCurrentCorrections { get; set; }
        public virtual IList<Card> Cards { get; set; }
    }
}
