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
using Patient_Cards.ViewModels.Base;
using Patient_Cards_Model.Interfaces;
using Patient_Cards_Model.DTO.GL;
using Patient_Cards.Events.PersonTest;

namespace Patient_Cards.ViewModels.Sharpness
{
    public class GLSharpnessViewModel : ViewModelBase
    {
        #region Properties
        private IList<GLSharpnessEyeViewModel> sharpnesses;
        public IList<GLSharpnessEyeViewModel> Sharpnesses
        {
            get { return sharpnesses; }
            set { SetProperty(ref sharpnesses, value); }
        }

        private GLSharpnessEyeViewModel selectedSharpness;
        public GLSharpnessEyeViewModel SelectedSharpness
        {
            get { return selectedSharpness; }
            set { SetProperty(ref selectedSharpness, value); }
        }
        #endregion

        #region Event tokens
        private SubscriptionToken clearFormEventToken;
        private SubscriptionToken personDataRequestEventToken;
        #endregion

        private readonly ISharpnessService sharpnessService;

        public GLSharpnessViewModel(IEventAggregator eventAggregator, IUnityContainer unityContainer,
                                    ISharpnessService sharpnessService, IDictionariesService dictionariesService)
            : base(eventAggregator, unityContainer, dictionariesService)
        {
            this.sharpnessService = sharpnessService;
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

                SetSharpnesses();
            }));
        }

        private async void SetSharpnesses()
        {
            IList<GLSharpnessDTO> sharpnesses = await Task.Run(() => sharpnessService.GetGLSharpnesses());

            Sharpnesses = new ObservableCollection<GLSharpnessEyeViewModel>();
            SelectedSharpness = null;

            foreach (GLSharpnessDTO s in sharpnesses)
            {
                Sharpnesses.Add(new GLSharpnessEyeViewModel(s));
            }
        }

        private void OnSubscribePersonDataRequestEvent()
            => eventAggregator.GetEvent<Events.Sharpness.GLSharpness.PersonDataResponseEvent>().Publish(this);

        private void OnSubscribeClearFormEvent()
            => SetSharpnesses();

        public override void UnsubscribePrismEvents()
        {
            base.UnsubscribePrismEvents();

            eventAggregator.GetEvent<PersonDataRequestEvent>().Unsubscribe(personDataRequestEventToken);
            eventAggregator.GetEvent<ClearFormEvent>().Unsubscribe(clearFormEventToken);
        }
    }
}
