using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Cards_Model.Entities.GL;
using Patient_Cards_Model.Entities.CL;

namespace Patient_Cards_Model.Entities
{
    public class Eye
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<GLSharpness> GLSharpnesses { get; set; }
        public virtual IList<CLSharpness> CLSharpnesses { get; set; }
        public virtual IList<GLMatchedCorrection> GLMachedCorrections { get; set; }
        public virtual IList<CLMatchedCorrection> CLMachedCorrections { get; set; }
        public virtual IList<GLCurrentCorrection> GLCurrentCorrections { get; set; }
        public virtual IList<CLCurrentCorrection> CLCurrentCorrections { get; set; }
    }
}
