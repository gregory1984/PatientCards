using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.Entities.CL
{
    public class CLSharpnessInterview
    {
        public virtual int Id { get; set; }
        public virtual IList<CLSharpness> CLSharpnesses { get; set; }
        public virtual IList<Card> Cards { get; set; }
    }
}
