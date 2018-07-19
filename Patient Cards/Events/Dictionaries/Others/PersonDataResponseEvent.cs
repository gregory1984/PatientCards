using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Cards.ViewModels.Dictionaries;
using Prism.Events;

namespace Patient_Cards.Events.Dictionaries.Others
{
    public class PersonDataResponseEvent : PubSubEvent<OthersViewModel>
    {
    }
}
