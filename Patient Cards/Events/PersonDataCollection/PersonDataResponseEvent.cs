using Patient_Cards.ViewModels.Base;
using Prism.Events;

namespace Patient_Cards.Events.PersonDataCollection
{
    public class PersonDataResponseEvent : PubSubEvent<ViewModelBase>
    {
        public string UserControlName { get; set; } = "";
    }
}
