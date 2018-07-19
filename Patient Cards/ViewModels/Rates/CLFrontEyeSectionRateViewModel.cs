using Prism.Commands;
using Prism.Mvvm;
using Prism.Events;
using Microsoft.Practices.Unity;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using Patient_Cards.Helpers;
using Patient_Cards.ViewModels.Rates;
using Patient_Cards.ViewModels.Base;
using Patient_Cards.ViewModels.Corrections;
using Patient_Cards_Model.Interfaces;
using Patient_Cards_Model.DTO.CL;
using Patient_Cards.Events.PersonTest;

namespace Patient_Cards.ViewModels.Rates
{
    public class CLFrontEyeSectionRateViewModel : ViewModelBase
    {
        #region Properties
        private IList<CLFrontEyeSectionRateIssueViewModel> issues;
        public IList<CLFrontEyeSectionRateIssueViewModel> Issues
        {
            get { return issues; }
            set { SetProperty(ref issues, value); }
        }

        private CLFrontEyeSectionRateIssueViewModel selectedIssue;
        public CLFrontEyeSectionRateIssueViewModel SelectedIssue
        {
            get { return selectedIssue; }
            set { SetProperty(ref selectedIssue, value); }
        }
        #endregion

        #region Event tokens
        private SubscriptionToken clearFormEventToken;
        private SubscriptionToken personDataRequestEventToken;
        #endregion

        private readonly IRatesService ratesService;

        public CLFrontEyeSectionRateViewModel(IEventAggregator eventAggregator, IUnityContainer unityContainer, IRatesService ratesService, IDictionariesService dictionariesService)
            : base(eventAggregator, unityContainer, dictionariesService)
        {
            this.ratesService = ratesService;
        }

        private DelegateCommand loaded;
        public DelegateCommand Loaded
        {
            get => loaded ?? (loaded = new DelegateCommand(() =>
            {
                clearFormEventToken = eventAggregator
                    .GetEvent<ClearFormEvent>()
                    .Subscribe(OnSubscribeClearFormEvent);

                personDataRequestEventToken = eventAggregator
                    .GetEvent<PersonDataRequestEvent>()
                    .Subscribe(OnSubscribePersonDataRequestEvent);

                SetRates();
            }));
        }

        private async void SetRates()
        {
            IList<CLFrontEyeSectionRateDTO> rates = await Task.Run(() => ratesService.GetCLFrontEyeSectionRates());

            Issues = new ObservableCollection<CLFrontEyeSectionRateIssueViewModel>();
            foreach (CLFrontEyeSectionRateDTO r in rates)
            {
                Issues.Add(new CLFrontEyeSectionRateIssueViewModel(r));
            }
        }

        private void OnSubscribePersonDataRequestEvent()
            => eventAggregator.GetEvent<Events.Rates.CLFrontEyeSectionRate.PersonDataResponseEvent>().Publish(this);

        private void OnSubscribeClearFormEvent()
            => SetRates();

        public override void UnsubscribePrismEvents()
        {
            base.UnsubscribePrismEvents();

            eventAggregator.GetEvent<PersonDataRequestEvent>().Unsubscribe(personDataRequestEventToken);
            eventAggregator.GetEvent<ClearFormEvent>().Unsubscribe(clearFormEventToken);
        }
    }
}
