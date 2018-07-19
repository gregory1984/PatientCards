using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Cards.Events.Payloads;
using Patient_Cards.ViewModels.Corrections.GL;
using Prism.Events;

namespace Patient_Cards.Events.Corrections.GL.GLCurrentCorrection
{
    public class PersonDataResponseEvent : PubSubEvent<GLCurrentCorrectionViewModel>
    {
    }
}
