using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.Entities.CL
{
    public class CLWearingType
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Card> CardsCurrent { get; set; }
        public virtual IList<Card> CardsTest { get; set; }
        public virtual IList<Card> CardsTrade { get; set; }
    }
}
