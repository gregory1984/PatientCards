using Prism.Events;
using Patient_Cards.Events.Payloads;

namespace Patient_Cards.Events.Pagination
{
    public class JumpToPageEvent : PubSubEvent<JumpToPagePayload>
    {
    }
}
