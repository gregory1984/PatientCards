using Prism.Commands;
using Prism.Mvvm;
using Prism.Events;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using Patient_Cards.Helpers;
using Patient_Cards.ViewModels.Rates;
using Patient_Cards.ViewModels.Base;
using Patient_Cards.ViewModels.Corrections;
using Patient_Cards_Model.Interfaces;
using Patient_Cards_Model.DTO;

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
                eventAggregator.ExecuteSafety(() =>
                {
                    SetRates();
                });
            }));
        }

        private void SetRates()
        {
            Issues = new ObservableCollection<CLMatchedCorrectionRateIssueViewModel>();
            foreach (CLMatchedCorrectionRateDTO r in ratesService.GetCLMatchedCorrectionRates())
            {
                Issues.Add(new CLMatchedCorrectionRateIssueViewModel(r));
            }
        }
    }
}
