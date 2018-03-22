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
using Patient_Cards.ViewModels.Base;
using Patient_Cards.ViewModels.Corrections;
using Patient_Cards_Model.Interfaces;
using Patient_Cards_Model.DTO.GL;

namespace Patient_Cards.ViewModels.Corrections.GL
{
    public class GLMatchedCorrectionViewModel : ViewModelBase
    {
        #region Properties
        private IList<GLMatchedCorrectionEyeViewModel> phoropterCorrections;
        public IList<GLMatchedCorrectionEyeViewModel> PhoropterCorrections
        {
            get { return phoropterCorrections; }
            set { SetProperty(ref phoropterCorrections, value); }
        }

        private GLMatchedCorrectionEyeViewModel selectedPhoropterCorrection;
        public GLMatchedCorrectionEyeViewModel SelectedPhoropterCorrection
        {
            get { return selectedPhoropterCorrection; }
            set { SetProperty(ref selectedPhoropterCorrection, value); }
        }

        private IList<GLMatchedCorrectionEyeViewModel> finallyCorrections;
        public IList<GLMatchedCorrectionEyeViewModel> FinallyCorrections
        {
            get { return finallyCorrections; }
            set { SetProperty(ref finallyCorrections, value); }
        }

        private GLMatchedCorrectionEyeViewModel selectedFinallyCorrection;
        public GLMatchedCorrectionEyeViewModel SelectedFinallyCorrection
        {
            get { return selectedFinallyCorrection; }
            set { SetProperty(ref selectedFinallyCorrection, value); }
        }

        private IList<GLFinallyMatchedCorrectionTypeDTO> finallyCorrectionTypes;
        public IList<GLFinallyMatchedCorrectionTypeDTO> FinallyCorrectionTypes
        {
            get { return finallyCorrectionTypes; }
            set { SetProperty(ref finallyCorrectionTypes, value); }
        }

        private GLFinallyMatchedCorrectionTypeDTO selectedFinallyCorrectionType;
        public GLFinallyMatchedCorrectionTypeDTO SelectedFinallyCorrectionType
        {
            get { return selectedFinallyCorrectionType; }
            set { SetProperty(ref selectedFinallyCorrectionType, value); }
        }

        private string finallyCorrectionTypeOptional = "";
        public string FinallyCorrectionTypeOptional
        {
            get { return finallyCorrectionTypeOptional; }
            set { SetProperty(ref finallyCorrectionTypeOptional, value); }
        }
        #endregion

        private readonly ICorrectionService correctionService;

        public GLMatchedCorrectionViewModel(IEventAggregator eventAggregator, IUnityContainer unityContainer, ICorrectionService correctionService, IDictionariesService dictionariesService)
            : base(eventAggregator, unityContainer, dictionariesService)
        {
            this.correctionService = correctionService;
        }

        private DelegateCommand loaded;
        public DelegateCommand Loaded
        {
            get => loaded ?? (loaded = new DelegateCommand(() =>
            {
                SetCorrections(GLCorrectionType.FromPhoropter);
                SetCorrections(GLCorrectionType.FinallyMatched);

                SetFinallyCorrectionTypes();
            }));
        }

        private async void SetCorrections(GLCorrectionType gLCorrectionType)
        {
            IList<GLMatchedCorrectionEyeViewModel> corrections = null;
            GLMatchedCorrectionEyeViewModel selectedCorrection = null;

            IList<GLMatchedCorrectionDTO> dtos = await Task.Run(() => correctionService.GetGLMatchedCorrections(gLCorrectionType));

            corrections = new ObservableCollection<GLMatchedCorrectionEyeViewModel>();
            foreach (GLMatchedCorrectionDTO d in dtos)
            {
                corrections.Add(new GLMatchedCorrectionEyeViewModel(d, dictionariesService));
            }
            selectedCorrection = null;

            switch (gLCorrectionType)
            {
                case GLCorrectionType.FromPhoropter: { PhoropterCorrections = corrections; SelectedPhoropterCorrection = selectedCorrection; break; }
                case GLCorrectionType.FinallyMatched: { FinallyCorrections = corrections; SelectedFinallyCorrection = selectedCorrection; break; }
            }
        }

        private async void SetFinallyCorrectionTypes()
        {
            IDictionary<int, GLFinallyMatchedCorrectionTypeDTO> types = await Task.Run(() => dictionariesService.GLFinallyMatchedCorrectionTypes);

            FinallyCorrectionTypes = new ObservableCollection<GLFinallyMatchedCorrectionTypeDTO>();
            FinallyCorrectionTypes.Add(new GLFinallyMatchedCorrectionTypeDTO { Id = null, Name = "-- Wybierz --" });
            foreach (GLFinallyMatchedCorrectionTypeDTO t in types.Values)
            {
                FinallyCorrectionTypes.Add(t);
            }
            SelectedFinallyCorrectionType = FinallyCorrectionTypes.First();
        }
    }
}
