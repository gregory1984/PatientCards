using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.Entities.GL
{
    public class GLSharpnessInterview
    {
        public virtual int Id { get; set; }
        public virtual IList<GLSharpness> GLSharpnesses { get; set; }
        public virtual IList<Card> Cards { get; set; }
    }
}
