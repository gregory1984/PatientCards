using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.Entities
{
    public class IllnessInterview
    {
        public virtual int Id { get; set; }
        public virtual string Optionals { get; set; }
        public virtual IList<Illness> Illnesses { get; set; }
        public virtual IList<Card> Cards { get; set; }
    }
}
