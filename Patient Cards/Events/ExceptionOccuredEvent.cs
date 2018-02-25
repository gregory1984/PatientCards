using System;
using Prism.Events;

namespace Patient_Cards.Events
{
    public class ExceptionOccuredEvent : PubSubEvent<Exception> { }
}
