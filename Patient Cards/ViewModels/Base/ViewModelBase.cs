using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.Practices.Unity;
using Prism.Mvvm;
using Prism.Events;
using Prism.Commands;
using Patient_Cards.Events;
using Patient_Cards_Model.Interfaces;

namespace Patient_Cards.ViewModels.Base
{
    public class ViewModelBase : BindableBase
    {
        public delegate void ExceptionOccuredDelegate(Exception exception);
        public event ExceptionOccuredDelegate ExceptionOccuredEvent;

        protected readonly IEventAggregator eventAggregator;
        protected readonly IUnityContainer unityContainer;
        protected readonly IDictionariesService dictionariesService;
        protected readonly IDictionary<EventBase, SubscriptionToken> events;

        public ViewModelBase(IEventAggregator eventAggregator, IUnityContainer unityContainer, IDictionariesService dictionariesService)
        {
            this.eventAggregator = eventAggregator;
            this.unityContainer = unityContainer;
            this.dictionariesService = dictionariesService;
            this.events = new Dictionary<EventBase, SubscriptionToken>();
        }

        /// <summary>
        /// Raises occured exception to exception handling subscribors.
        /// </summary>
        /// <param name="ex">Exception</param>
        protected void RaiseException(Exception ex)
        {
            eventAggregator.GetEvent<ExceptionOccuredEvent>().Publish(ex);
        }

        /// <summary>
        /// Sets class as exception handling subscribor.
        /// </summary>
        /// <remarks>
        /// One exception handling subscribor per application is the best setting at all.
        /// </remarks>
        protected void SubscribeExceptionHandling()
        {
            events.Add(
                eventAggregator.GetEvent<ExceptionOccuredEvent>(),
                eventAggregator.GetEvent<ExceptionOccuredEvent>().Subscribe(ex => ExceptionOccuredEvent?.Invoke(ex)));
        }

        /// <summary>
        /// Unsubscribes Prism events among all derived classes.
        /// </summary>
        public virtual void UnsubscribePrismEvents()
        {
            foreach (KeyValuePair<EventBase, SubscriptionToken> e in events)
            {
                e.Key.Unsubscribe(e.Value);
            }
        }
    }
}
