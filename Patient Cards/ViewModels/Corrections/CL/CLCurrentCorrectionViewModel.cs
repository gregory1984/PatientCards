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
using Patient_Cards_Model.DTO.CL;
using Patient_Cards.Events.PersonTest;

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

        #region Event tokens
        private SubscriptionToken clearFormEventToken;
        private SubscriptionToken personDataRequestEventToken;
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
                clearFormEventToken = eventAggregator
                    .GetEvent<ClearFormEvent>()
                    .Subscribe(OnSubscribeClearFormEvent);

                personDataRequestEventToken = eventAggregator
                    .GetEvent<PersonDataRequestEvent>()
                    .Subscribe(OnSubscribePersonDataRequestEvent);

                SetCorrections();
            }));
        }

        private void OnSubscribeClearFormEvent()
        {
            SetCorrections();

            FromWhen = "";
            VisusBothEyes = null;
        }

        private void OnSubscribePersonDataRequestEvent()
            => eventAggregator.GetEvent<Events.Corrections.CL.CLCurrentCorrection.PersonDataResponseEvent>().Publish(this);

        private async void SetCorrections()
        {
            try
            {
                IList<CLCurrentCorrectionDTO> corrections = await Task.Run(() => correctionService.GetCLCurrentCorrections());

                Corrections = new ObservableCollection<CLCurrentCorrectionEyeViewModel>();
                foreach (CLCurrentCorrectionDTO c in corrections)
                {
                    Corrections.Add(new CLCurrentCorrectionEyeViewModel(c));
                }
            }
            catch (Exception ex) { PropagateException(ex); }
        }

        public override void UnsubscribePrismEvents()
        {
            base.UnsubscribePrismEvents();

            eventAggregator.GetEvent<ClearFormEvent>().Unsubscribe(clearFormEventToken);
            eventAggregator.GetEvent<Events.Corrections.CL.CLCurrentCorrection.PersonDataResponseEvent>().Unsubscribe(personDataRequestEventToken);
        }
    }
}
