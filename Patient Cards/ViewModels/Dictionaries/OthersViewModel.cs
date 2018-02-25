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

        private string othersOptional = "";
        public string OthersOptional
        {
            get { return othersOptional; }
            set { SetProperty(ref othersOptional, value); }
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
                eventAggregator.ExecuteSafety(() => GetComplaints());
            }));
        }

        private void GetComplaints()
        {
            Others = new ObservableCollection<DictionaryViewModel>();
            foreach (OtherDTO c in dictionariesService.Others.Values)
            {
                Others.Add(new DictionaryViewModel(c.Id.Value, c.Name));
            }
            SelectedOther = null;
        }
    }
}
