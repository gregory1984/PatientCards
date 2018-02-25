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
using Patient_Cards_Model.DTO.CL;

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
                eventAggregator.ExecuteSafety(() =>
                {
                    GetRates();
                });
            }));
        }

        private void GetRates()
        {
            Issues = new ObservableCollection<CLFrontEyeSectionRateIssueViewModel>();
            foreach (CLFrontEyeSectionRateDTO r in ratesService.GetCLFrontEyeSectionRates())
            {
                Issues.Add(new CLFrontEyeSectionRateIssueViewModel(r));
            }
        }
    }
}
