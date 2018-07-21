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
    public class ComplaintsViewModel : ViewModelBase
    {
        #region Properties
        private IList<DictionaryViewModel> complaints;
        public IList<DictionaryViewModel> Complaints
        {
            get { return complaints; }
            set { SetProperty(ref complaints, value); }
        }

        private DictionaryViewModel selectedComplaint;
        public DictionaryViewModel SelectedComplaint
        {
            get { return selectedComplaint; }
            set
            {
                SetProperty(ref selectedComplaint, value);
                if (SelectedComplaint != null)
                    SelectedComplaint.IsChecked = !SelectedComplaint.IsChecked;
            }
        }

        private string complaintsOptional = "";
        public string ComplaintsOptional
        {
            get { return complaintsOptional; }
            set { SetProperty(ref complaintsOptional, value); }
        }
        #endregion

        public ComplaintsViewModel(IEventAggregator eventAggregator, IUnityContainer unityContainer, IDictionariesService dictionariesService)
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

                SetComplaints();
            }));
        }

        private async void SetComplaints()
        {
            IDictionary<int, ComplaintDTO> complaints = await Task.Run(() => dictionariesService.Complaints);

            Complaints = new ObservableCollection<DictionaryViewModel>();
            foreach (ComplaintDTO c in complaints.Values)
            {
                Complaints.Add(new DictionaryViewModel(c.Id.Value, c.Name));
            }
            SelectedComplaint = null;
        }

        private void OnSubscribePersonDataRequestEvent()
            => eventAggregator.GetEvent<PersonDataResponseEvent>().Publish(this);

        private void OnSubscribeClearFormEvent()
        {
            ComplaintsOptional = "";
            SelectedComplaint = null;

            foreach (DictionaryViewModel c in Complaints)
            {
                c.IsChecked = false;
            }
        }
    }
}
