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
using Patient_Cards_Model.Interfaces;
using Patient_Cards.ViewModels.Base;
using Patient_Cards_Model.DTO.CL;
using Patient_Cards.Events.PersonTest;

namespace Patient_Cards.ViewModels.Sharpness
{
    public class CLSharpnessViewModel : ViewModelBase
    {
        #region Properties
        private IList<CLSharpnessEyeViewModel> sharpnesses;
        public IList<CLSharpnessEyeViewModel> Sharpnesses
        {
            get { return sharpnesses; }
            set { SetProperty(ref sharpnesses, value); }
        }

        private CLSharpnessEyeViewModel selectedSharpness;
        public CLSharpnessEyeViewModel SelectedSharpness
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

        public CLSharpnessViewModel(IEventAggregator eventAggregator, IUnityContainer unityContainer,
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
            IList<CLSharpnessDTO> sharpnesses = await Task.Run(() => sharpnessService.GetCLSharpnesses());

            Sharpnesses = new ObservableCollection<CLSharpnessEyeViewModel>();
            SelectedSharpness = null;

            foreach (CLSharpnessDTO s in sharpnesses)
            {
                Sharpnesses.Add(new CLSharpnessEyeViewModel(s));
            }
        }

        private void OnSubscribePersonDataRequestEvent()
            => eventAggregator.GetEvent<Events.Sharpness.CLSharpness.PersonDataResponseEvent>().Publish(this);

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
