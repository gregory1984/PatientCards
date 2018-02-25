using Prism.Commands;
using Prism.Mvvm;
using Prism.Events;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using Patient_Cards.Helpers;
using Patient_Cards.ViewModels.Base;
using Patient_Cards.ViewModels.Corrections;
using Patient_Cards_Model.Interfaces;
using Patient_Cards_Model.DTO;

namespace Patient_Cards.ViewModels.Corrections.CL
{
    public class CLCurrentCorrectionViewModel : ViewModelBase
    {
        #region Properties
        private IList<CLCurrentCorrectionEyeViewModel> corrections;
        public IList<CLCurrentCorrectionEyeViewModel> Corrections
        {
            get { return corrections; }
            set { SetProperty(ref corrections, value); }
        }

        private CLCurrentCorrectionEyeViewModel selectedCorrection;
        public CLCurrentCorrectionEyeViewModel SelectedCorrection
        {
            get { return selectedCorrection; }
            set { SetProperty(ref selectedCorrection, value); }
        }

        private string fromWhen = "";
        public string FromWhen
        {
            get { return fromWhen; }
            set { SetProperty(ref fromWhen, value); }
        }

        private decimal? visusBothEyes;
        public decimal? VisusBothEyes
        {
            get { return visusBothEyes; }
            set { SetProperty(ref visusBothEyes, value); }
        }
        #endregion

        private readonly ICorrectionService correctionService;

        public CLCurrentCorrectionViewModel(IEventAggregator eventAggregator, IUnityContainer unityContainer, ICorrectionService correctionService, IDictionariesService dictionariesService)
            : base(eventAggregator, unityContainer, dictionariesService)
        {
            this.correctionService = correctionService;
        }

        private DelegateCommand loaded;
        public DelegateCommand Loaded
        {
            get => loaded ?? (loaded = new DelegateCommand(() =>
            {
                eventAggregator.ExecuteSafety(() =>
                {
                    GetCorrections();
                });
            }));
        }

        private void GetCorrections()
        {
            Corrections = new ObservableCollection<CLCurrentCorrectionEyeViewModel>();
            foreach (CLCurrentCorrectionDTO c in correctionService.GetCLCurrentCorrections())
            {
                Corrections.Add(new CLCurrentCorrectionEyeViewModel(c));
            }
        }
    }
}
