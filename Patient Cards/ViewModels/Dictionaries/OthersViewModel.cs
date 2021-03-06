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
using Patient_Cards.ViewModels.Corrections;
using Patient_Cards_Model.Interfaces;
using Patient_Cards_Model.DTO;
using Patient_Cards.Events.PersonDataCollection;

namespace Patient_Cards.ViewModels.Dictionaries
{
    public class OthersViewModel : ViewModelBase
    {
        #region Properties
        private IList<DictionaryViewModel> others;
        public IList<DictionaryViewModel> Others
        {
            get { return others; }
            set { SetProperty(ref others, value); }
        }

        private DictionaryViewModel selectedOther;
        public DictionaryViewModel SelectedOther
        {
            get { return selectedOther; }
            set
            {
                SetProperty(ref selectedOther, value);
                if (SelectedOther != null)
                    SelectedOther.IsChecked = !SelectedOther.IsChecked;
            }
        }

        private string optionals = "";
        public string Optionals
        {
            get { return optionals; }
            set { SetProperty(ref optionals, value); }
        }
        #endregion

        public OthersViewModel(IEventAggregator eventAggregator, IUnityContainer unityContainer, IDictionariesService dictionariesService)
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

                SetOthers();
            }));
        }

        private async void SetOthers()
        {
            IDictionary<int, OtherDTO> others = await Task.Run(() => dictionariesService.Others);

            Others = new ObservableCollection<DictionaryViewModel>();
            foreach (OtherDTO c in others.Values)
            {
                Others.Add(new DictionaryViewModel(c.Id.Value, c.Name));
            }
            SelectedOther = null;
        }

        private void OnSubscribePersonDataRequestEvent()
            => eventAggregator.GetEvent<PersonDataResponseEvent>().Publish(this);

        private void OnSubscribeClearFormEvent()
        {
            Optionals = "";
            SelectedOther = null;

            foreach (DictionaryViewModel o in Others)
            {
                o.IsChecked = false;
            }
        }
    }
}
