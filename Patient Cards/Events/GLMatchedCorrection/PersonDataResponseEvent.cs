using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Cards.ViewModels.Corrections.GL;
using Prism.Events;

namespace Patient_Cards.Events.GLMatchedCorrection
{
    public class PersonDataResponseEvent : PubSubEvent<GLMatchedCorrectionViewModel>
    {
    }
}
