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
using Patient_Cards_Model.DTO;
using Patient_Cards.Events.PersonTest;

namespace Patient_Cards.ViewModels.Dictionaries
{
    public class MedicamentsViewModel : ViewModelBase
    {
        #region Properties
        private IList<DictionaryViewModel> medicaments;
        public IList<DictionaryViewModel> Medicaments
        {
            get { return medicaments; }
            set { SetProperty(ref medicaments, value); }
        }

        private DictionaryViewModel selectedMedicament;
        public DictionaryViewModel SelectedMedicament
        {
            get { return selectedMedicament; }
            set
            {
                SetProperty(ref selectedMedicament, value);
                if (SelectedMedicament != null)
                    SelectedMedicament.IsChecked = !SelectedMedicament.IsChecked;
            }
        }

        private string medicamentsOptional = "";
        public string MedicamentsOptional
        {
            get { return medicamentsOptional; }
            set { SetProperty(ref medicamentsOptional, value); }
        }
        #endregion

        #region Event tokens
        private SubscriptionToken clearFormEventToken;
        private SubscriptionToken personDataRequestEventToken;
        #endregion

        public MedicamentsViewModel(IEventAggregator eventAggregator, IUnityContainer unityContainer, IDictionariesService dictionariesService)
            : base(eventAggregator, unityContainer, dictionariesService)
        {

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

                SetMedicaments();
            }));
        }

        private async void SetMedicaments()
        {
            IDictionary<int, MedicamentDTO> medicaments = await Task.Run(() => dictionariesService.Medicaments);

            Medicaments = new ObservableCollection<DictionaryViewModel>();
            foreach (MedicamentDTO c in medicaments.Values)
            {
                Medicaments.Add(new DictionaryViewModel(c.Id.Value, c.Name));
            }
            SelectedMedicament = null;
        }

        private void OnSubscribePersonDataRequestEvent()
            => eventAggregator.GetEvent<Events.Dictionaries.Medicaments.PersonDataResponseEvent>().Publish(this);

        private void OnSubscribeClearFormEvent()
        {
            MedicamentsOptional = "";
            SelectedMedicament = null;

            foreach (DictionaryViewModel m in Medicaments)
            {
                m.IsChecked = false;
            }
        }

        public override void UnsubscribePrismEvents()
        {
            base.UnsubscribePrismEvents();

            eventAggregator.GetEvent<PersonDataRequestEvent>().Unsubscribe(personDataRequestEventToken);
            eventAggregator.GetEvent<ClearFormEvent>().Unsubscribe(clearFormEventToken);
        }
    }
}
