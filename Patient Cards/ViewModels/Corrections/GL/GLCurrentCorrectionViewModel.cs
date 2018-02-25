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

namespace Patient_Cards.ViewModels.Corrections.GL
{
    public class GLCurrentCorrectionViewModel : ViewModelBase
    {
        #region Properties
        private IList<GLCurrentCorrectionEyeViewModel> corrections;
        public IList<GLCurrentCorrectionEyeViewModel> Corrections
        {
            get { return corrections; }
            set { SetProperty(ref corrections, value); }
        }

        private GLCurrentCorrectionEyeViewModel selectedCorrection;
        public GLCurrentCorrectionEyeViewModel SelectedCorrection
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
        #endregion

        private readonly ICorrectionService correctionService;

        public GLCurrentCorrectionViewModel(IEventAggregator eventAggregator, IUnityContainer unityContainer, ICorrectionService correctionService, IDictionariesService dictionariesService)
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
            Corrections = new ObservableCollection<GLCurrentCorrectionEyeViewModel>();
            foreach (GLCurrentCorrectionDTO c in correctionService.GetGLCurrentCorrections())
            {
                Corrections.Add(new GLCurrentCorrectionEyeViewModel(c, dictionariesService));
            }
        }
    }
}
