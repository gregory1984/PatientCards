using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.Entities
{
    public class Complaint
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<ComplaintInterview> ComplaintInterviews { get; set; }
    }
}
