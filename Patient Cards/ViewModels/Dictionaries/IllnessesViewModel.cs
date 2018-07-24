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
using Patient_Cards.Events.PersonDataCollection;

namespace Patient_Cards.ViewModels.Dictionaries
{
    public class IllnessesViewModel : ViewModelBase
    {
        #region Properties
        private IList<DictionaryViewModel> illnesses;
        public IList<DictionaryViewModel> Illnesses
        {
            get { return illnesses; }
            set { SetProperty(ref illnesses, value); }
        }

        private DictionaryViewModel selectedIllness;
        public DictionaryViewModel SelectedIllness
        {
            get { return selectedIllness; }
            set
            {
                SetProperty(ref selectedIllness, value);
                if (SelectedIllness != null)
                    SelectedIllness.IsChecked = !SelectedIllness.IsChecked;
            }
        }

        private string optionals = "";
        public string Optionals
        {
            get { return optionals; }
            set { SetProperty(ref optionals, value); }
        }
        #endregion

        public IllnessesViewModel(IEventAggregator eventAggregator, IUnityContainer unityContainer, IDictionariesService dictionariesService)
            : base(eventAggregator, unityContainer, dictionariesService)
        {

        }

        private DelegateCommand loaded;
        public DelegateCommand Loaded
        {
            get => loaded ?? (loaded = new DelegateCommand(() =>
            {
                events.Add(
                    eventAggregator.GetEvent<ClearFormEvent>(),
                    eventAggregator.GetEvent<ClearFormEvent>().Subscribe(OnSubscribeClearFormEvent));

                events.Add(
                    eventAggregator.GetEvent<PersonDataRequestEvent>(),
                    eventAggregator.GetEvent<PersonDataRequestEvent>().Subscribe(OnSubscribePersonDataRequestEvent));

                SetIllnesses();
            }));
        }

        private async void SetIllnesses()
        {
            IDictionary<int, IllnessDTO> illnesses = await Task.Run(() => dictionariesService.Illnesses);

            Illnesses = new ObservableCollection<DictionaryViewModel>();
            foreach (IllnessDTO i in illnesses.Values)
            {
                Illnesses.Add(new DictionaryViewModel(i.Id.Value, i.Name));
            }
            SelectedIllness = null;
        }

        private void OnSubscribePersonDataRequestEvent()
            => eventAggregator.GetEvent<PersonDataResponseEvent>().Publish(this);

        private void OnSubscribeClearFormEvent()
        {
            Optionals = "";
            SelectedIllness = null;

            foreach (DictionaryViewModel i in Illnesses)
            {
                i.IsChecked = false;
            }
        }
    }
}
