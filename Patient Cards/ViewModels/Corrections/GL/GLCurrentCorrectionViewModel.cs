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
using Patient_Cards.Events.PersonTest;
using Patient_Cards_Model.Interfaces;
using Patient_Cards_Model.DTO.GL;

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

        private string currentGLType = "";
        public string CurrentGLType
        {
            get { return currentGLType; }
            set { SetProperty(ref currentGLType, value); }
        }
        #endregion

        #region Event tokens
        private SubscriptionToken clearFormEventToken;
        private SubscriptionToken personDataRequestEventToken;
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

            FromWhen = CurrentGLType = "";
        }

        private void OnSubscribePersonDataRequestEvent()
            => eventAggregator.GetEvent<Events.GLCurrentCorrection.PersonDataResponseEvent>().Publish(this);

        private async void SetCorrections()
        {
            IList<GLCurrentCorrectionDTO> corrections = await Task.Run(() => correctionService.GetGLCurrentCorrections());

            Corrections = new ObservableCollection<GLCurrentCorrectionEyeViewModel>();
            foreach (GLCurrentCorrectionDTO c in corrections)
            {
                Corrections.Add(new GLCurrentCorrectionEyeViewModel(c, dictionariesService));
            }
        }

        public override void UnsubscribePrismEvents()
        {
            base.UnsubscribePrismEvents();

            eventAggregator.GetEvent<ClearFormEvent>().Unsubscribe(clearFormEventToken);
            eventAggregator.GetEvent<PersonDataRequestEvent>().Unsubscribe(personDataRequestEventToken);
        }
    }
}
