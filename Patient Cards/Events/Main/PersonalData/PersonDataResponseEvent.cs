using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Cards.ViewModels.Main;
using Prism.Events;

namespace Patient_Cards.Events.Main.PersonalData
{
    public class PersonDataResponseEvent : PubSubEvent<PersonalDataViewModel>
    {
    }
}
