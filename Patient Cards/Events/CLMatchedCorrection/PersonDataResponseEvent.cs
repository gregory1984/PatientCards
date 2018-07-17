using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Cards.ViewModels.Corrections.CL;
using Prism.Events;

namespace Patient_Cards.Events.CLMatchedCorrection
{
    public class PersonDataResponseEvent : PubSubEvent<CLMatchedCorrectionViewModel>
    {
    }
}
