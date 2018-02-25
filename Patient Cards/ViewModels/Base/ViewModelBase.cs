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
        protected readonly IEventAggregator eventAggregator;
        protected readonly IUnityContainer unityContainer;
        protected readonly IDictionariesService dictionariesService;

        protected SubscriptionToken exceptionOccuredToken;

        public ViewModelBase(IEventAggregator eventAggregator, IUnityContainer unityContainer, IDictionariesService dictionariesService)
        {
            this.eventAggregator = eventAggregator;
            this.unityContainer = unityContainer;
            this.dictionariesService = dictionariesService;
        }

        protected void SubscribeExceptionHandling()
            => exceptionOccuredToken = eventAggregator.GetEvent<ExceptionOccuredEvent>()
                .Subscribe(ex => ExceptionOccured?.Invoke(ex));

        public virtual void UnsubscribePrismEvents()
            => eventAggregator.GetEvent<ExceptionOccuredEvent>().Unsubscribe(exceptionOccuredToken);

        public delegate void ExceptionOccuredDelegate(Exception exception);
        public event ExceptionOccuredDelegate ExceptionOccured;
    }
}
