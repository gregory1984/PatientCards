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
using Patient_Cards_Model.DTO.CL;

namespace Patient_Cards.ViewModels.Corrections.CL
{
    public class CLMatchedCorrectionViewModel : ViewModelBase
    {
        #region Properties For Testing
        private IList<CLMatchedCorrectionEyeViewModel> forTestingCorrections;
        public IList<CLMatchedCorrectionEyeViewModel> ForTestingCorrections
        {
            get { return forTestingCorrections; }
            set { SetProperty(ref forTestingCorrections, value); }
        }

        private CLMatchedCorrectionEyeViewModel selectedForTestingCorrection;
        public CLMatchedCorrectionEyeViewModel SelectedForTestingCorrection
        {
            get { return selectedForTestingCorrection; }
            set { SetProperty(ref selectedForTestingCorrection, value); }
        }

        private IList<CLWearingTypeDTO> forTestingWearingTypes;
        public IList<CLWearingTypeDTO> ForTestingWearingTypes
        {
            get { return forTestingWearingTypes; }
            set { SetProperty(ref forTestingWearingTypes, value); }
        }

        private CLWearingTypeDTO selectedForTestingWearingType;
        public CLWearingTypeDTO SelectedForTestingWearingType
        {
            get { return selectedForTestingWearingType; }
            set { SetProperty(ref selectedForTestingWearingType, value); }
        }

        private string forTestingName = "";
        public string ForTestingName
        {
            get { return forTestingName; }
            set { SetProperty(ref forTestingName, value); }
        }

        private string forTestingVendor = "";
        public string ForTestingVendor
        {
            get { return forTestingVendor; }
            set { SetProperty(ref forTestingVendor, value); }
        }

        private string forTestingLiquid = "";
        public string ForTestingLiquid
        {
            get { return forTestingLiquid; }
            set { SetProperty(ref forTestingLiquid, value); }
        }
        #endregion

        #region Properties For Trading
        private IList<CLMatchedCorrectionEyeViewModel> forTradingCorrections;
        public IList<CLMatchedCorrectionEyeViewModel> ForTradingCorrections
        {
            get { return forTradingCorrections; }
            set { SetProperty(ref forTradingCorrections, value); }
        }

        private CLMatchedCorrectionEyeViewModel selectedForTradingCorrection;
        public CLMatchedCorrectionEyeViewModel SelectedForTradingCorrection
        {
            get { return selectedForTradingCorrection; }
            set { SetProperty(ref selectedForTradingCorrection, value); }
        }

        private IList<CLWearingTypeDTO> forTradingWearingTypes;
        public IList<CLWearingTypeDTO> ForTradingWearingTypes
        {
            get { return forTradingWearingTypes; }
            set { SetProperty(ref forTradingWearingTypes, value); }
        }

        private CLWearingTypeDTO selectedForTradingWearingType;
        public CLWearingTypeDTO SelectedForTradingWearingType
        {
            get { return selectedForTradingWearingType; }
            set { SetProperty(ref selectedForTradingWearingType, value); }
        }

        private string forTradingName = "";
        public string ForTradingName
        {
            get { return forTradingName; }
            set { SetProperty(ref forTradingName, value); }
        }

        private string forTradingVendor = "";
        public string ForTradingVendor
        {
            get { return forTradingVendor; }
            set { SetProperty(ref forTradingVendor, value); }
        }

        private string forTradingLiquid = "";
        public string ForTradingLiquid
        {
            get { return forTradingLiquid; }
            set { SetProperty(ref forTradingLiquid, value); }
        }
        #endregion

        private readonly ICorrectionService correctionService;

        public CLMatchedCorrectionViewModel(IEventAggregator eventAggregator, IUnityContainer unityContainer, ICorrectionService correctionService, IDictionariesService dictionariesService)
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
                    GetCorrections(CLCorrectionType.ForTesting);
                    GetCorrections(CLCorrectionType.ForTrading);

                    GetWearingTypes();
                });
            }));
        }

        private void GetCorrections(CLCorrectionType cLCorrectionType)
        {
            IList<CLMatchedCorrectionEyeViewModel> corrections = null;
            CLMatchedCorrectionEyeViewModel selectedCorrection = null;

            corrections = new ObservableCollection<CLMatchedCorrectionEyeViewModel>();
            foreach (CLMatchedCorrectionDTO d in correctionService.GetCLMatchedCorrections(cLCorrectionType))
            {
                corrections.Add(new CLMatchedCorrectionEyeViewModel(d));
            }
            selectedCorrection = null;

            switch (cLCorrectionType)
            {
                case CLCorrectionType.ForTesting: { ForTestingCorrections = corrections; SelectedForTestingCorrection = selectedCorrection; break; }
                case CLCorrectionType.ForTrading: { ForTradingCorrections = corrections; SelectedForTradingCorrection = selectedCorrection; break; }
            }
        }

        private void GetWearingTypes()
        {
            ForTestingWearingTypes = new ObservableCollection<CLWearingTypeDTO>();
            ForTestingWearingTypes.Add(new CLWearingTypeDTO { Id = null, Name = "-- Wybierz --" });

            ForTradingWearingTypes = new ObservableCollection<CLWearingTypeDTO>();
            ForTradingWearingTypes.Add(new CLWearingTypeDTO { Id = null, Name = "-- Wybierz --" });

            foreach (CLWearingTypeDTO d in dictionariesService.CLWearingTypes.Values)
            {
                ForTestingWearingTypes.Add(d);
                ForTradingWearingTypes.Add(d);
            }

            SelectedForTestingWearingType = ForTestingWearingTypes.First();
            SelectedForTradingWearingType = ForTradingWearingTypes.First();
        }
    }
}
