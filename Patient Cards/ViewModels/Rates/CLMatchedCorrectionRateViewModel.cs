﻿using Prism.Commands;
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
using Patient_Cards.Events.PersonDataCollection;

namespace Patient_Cards.ViewModels.Rates
{
    public class CLMatchedCorrectionRateViewModel : ViewModelBase
    {
        #region Properties
        private IList<CLMatchedCorrectionRateIssueViewModel> issues;
        public IList<CLMatchedCorrectionRateIssueViewModel> Issues
        {
            get { return issues; }
            set { SetProperty(ref issues, value); }
        }

        private CLMatchedCorrectionRateIssueViewModel selectedIssue;
        public CLMatchedCorrectionRateIssueViewModel SelectedIssue
        {
            get { return selectedIssue; }
            set { SetProperty(ref selectedIssue, value); }
        }
        #endregion

        private readonly IRatesService ratesService;

        public CLMatchedCorrectionRateViewModel(IEventAggregator eventAggregator, IUnityContainer unityContainer, IRatesService ratesService, IDictionariesService dictionariesService)
            : base(eventAggregator, unityContainer, dictionariesService)
        {
            this.ratesService = ratesService;
        }

        private DelegateCommand loaded;
        public DelegateCommand Loaded
        {
            get => loaded ?? (loaded = new DelegateCommand(() =>
            {
                events.Add(
                    eventAggregator.GetEvent<ClearFormEvent>(),
                    eventAggregator.GetEvent<ClearFormEvent>().Subscribe(OnSubscribeClearFormEvent));

                events.Add(
                    eventAggregator.GetEvent<PersonDataRequestEvent>(),
                    eventAggregator.GetEvent<PersonDataRequestEvent>().Subscribe(OnSubscribePersonDataRequestEvent));

                SetRates();
            }));
        }

        private async void SetRates()
        {
            IList<CLMatchedCorrectionRateDTO> rates = await Task.Run(() => ratesService.GetCLMatchedCorrectionRates());

            Issues = new ObservableCollection<CLMatchedCorrectionRateIssueViewModel>();
            foreach (CLMatchedCorrectionRateDTO r in rates)
            {
                Issues.Add(new CLMatchedCorrectionRateIssueViewModel(r));
            }
        }

        private void OnSubscribePersonDataRequestEvent()
            => eventAggregator.GetEvent<PersonDataResponseEvent>().Publish(this);

        private void OnSubscribeClearFormEvent()
            => SetRates();
    }
}
