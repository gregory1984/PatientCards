using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Cards.Events.Payloads;
using Prism.Events;

namespace Patient_Cards.Events.GLCurrentCorrection
{
    public class PersonDataResponseEvent : PubSubEvent<Payloads.GLCurrentCorrection.PersonDataPayload>
    {
    }
}
