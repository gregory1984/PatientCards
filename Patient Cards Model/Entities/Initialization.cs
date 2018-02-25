using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.Entities
{
    public class Initialization
    {
        public virtual int Id { get; set; }
        public virtual string Version { get; set; }
        public virtual DateTime Date { get; set; }
    }
}
