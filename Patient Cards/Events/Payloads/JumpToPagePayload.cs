using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards.Events.Payloads
{
    public class JumpToPagePayload
    {
        public string UserControlName { get; set; }
        public int No { get; set; }
    }
}
