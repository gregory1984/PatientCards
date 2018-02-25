using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Cards_Model.Entities.GL;

namespace Patient_Cards_Model.Entities
{
    public class Base
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<GLCurrentCorrection> GLCurrentCorrections { get; set; }
        public virtual IList<GLMatchedCorrection> GLMatchedCorrections { get; set; }
    }
}
