using Prism.Commands;
using Prism.Mvvm;
using Prism.Events;
using Microsoft.Practices.Unity;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Collections.ObjectModel;
using Patient_Cards.Helpers;
using Patient_Cards.ViewModels.Base;
using Patient_Cards.ViewModels.Corrections;
using Patient_Cards_Model.Interfaces;
using Patient_Cards_Model.DTO;
using Patient_Cards_Model.DTO.CL;
using Patient_Cards.Events.PersonDataCollection;


namespace Patient_Cards.ViewModels.Main
{
    public class PersonalDataViewModel : ViewModelBase
    {
        #region Properties
        private DateTime currentVisitDate;
        public DateTime CurrentVisitDate
        {
            get { return currentVisitDate; }
            set { SetProperty(ref currentVisitDate, value); }
        }

        private string name = "";
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string surname = "";
        public string Surname
        {
            get { return surname; }
            set { SetProperty(ref surname, value); }
        }

        private string age;
        public string Age
        {
            get { return age; }
            set { SetProperty(ref age, value); }
        }

        private string visitCause = "";
        public string VisitCause
        {
            get { return visitCause; }
            set { SetProperty(ref visitCause, value); }
        }

        private DateTime? previousVisitDate;
        public DateTime? PreviousVisitDate
        {
            get { return previousVisitDate; }
            set { SetProperty(ref previousVisitDate, value); }
        }

        private string professionOrHobby = "";
        public string ProfessionOrHobby
        {
            get { return professionOrHobby; }
            set { SetProperty(ref professionOrHobby, value); }
        }

        private IList<DistanceDTO> distances;
        public IList<DistanceDTO> Distances
        {
            get { return distances; }
            set { SetProperty(ref distances, value); }
        }

        private DistanceDTO selectedDistance;
        public DistanceDTO SelectedDistance
        {
            get { return selectedDistance; }
            set { SetProperty(ref selectedDistance, value); }
        }

        private bool isComputerProfession;
        public bool IsComputerProfession
        {
            get { return isComputerProfession; }
            set { SetProperty(ref isComputerProfession, value); }
        }

        private string computerProfessionOptional = "";
        public string ComputerProfessionOptional
        {
            get { return computerProfessionOptional; }
            set { SetProperty(ref computerProfessionOptional, value); }
        }

        private bool isCarDriving;
        public bool IsCarDriving
        {
            get { return isCarDriving; }
            set { SetProperty(ref isCarDriving, value); }
        }

        private string carDrivingOptional = "";
        public string CarDrivingOptional
        {
            get { return carDrivingOptional; }
            set { SetProperty(ref carDrivingOptional, value); }
        }

        private IList<CLProfessionConditionDTO> cLProfessionConditions;
        public IList<CLProfessionConditionDTO> CLProfessionConditions
        {
            get { return cLProfessionConditions; }
            set { SetProperty(ref cLProfessionConditions, value); }
        }

        private CLProfessionConditionDTO selectedCLProfessionCondition;
        public CLProfessionConditionDTO SelectedCLProfessionCondition
        {
            get { return selectedCLProfessionCondition; }
            set { SetProperty(ref selectedCLProfessionCondition, value); }
        }

        private string cLProfessionConditionsOptional = "";
        public string CLProfessionContitionsOptional
        {
            get { return cLProfessionConditionsOptional; }
            set { SetProperty(ref cLProfessionConditionsOptional, value); }
        }

        private string treatments = "";
        public string Treatments
        {
            get { return treatments; }
            set { SetProperty(ref treatments, value); }
        }

        private string comments = "";
        public string Comments
        {
            get { return comments; }
            set { SetProperty(ref comments, value); }
        }

        private string controlVisitDate = "";
        public string ControlVisitDate
        {
            get { return controlVisitDate; }
            set { SetProperty(ref controlVisitDate, value); }
        }
        #endregion

        public PersonalDataViewModel(IEventAggregator eventAggregator, IUnityContainer unityContainer, IDictionariesService dictionariesService)
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

                SetDistances();
                SetCLProfessionConditions();
                SetDates();
            }));
        }

        private void SetDates()
        {
            //  TODO: Implement async either.
            CurrentVisitDate = DateTime.Today;
            PreviousVisitDate = null;
        }

        private async void SetDistances()
        {
            IDictionary<int, DistanceDTO> distances = await Task.Run(() => dictionariesService.Distances);

            Distances = new ObservableCollection<DistanceDTO> { new DistanceDTO { Id = null, Name = "Wybierz" } };
            foreach (DistanceDTO d in distances.Values)
            {
                Distances.Add(d);
            }
            SelectedDistance = Distances.First();
        }

        private async void SetCLProfessionConditions()
        {
            IDictionary<int, CLProfessionConditionDTO> conditions = await Task.Run(() => dictionariesService.CLProfessionConditions);

            CLProfessionConditions = new ObservableCollection<CLProfessionConditionDTO> { new CLProfessionConditionDTO { Id = null, Name = "Wybierz" } };
            foreach (CLProfessionConditionDTO d in conditions.Values)
            {
                CLProfessionConditions.Add(d);
            }
            SelectedCLProfessionCondition = CLProfessionConditions.First();
        }

        private void OnSubscribeClearFormEvent()
            => ClearForm();

        private void ClearForm()
        {
            Name = Surname = VisitCause = ProfessionOrHobby = ComputerProfessionOptional =
                CarDrivingOptional = CLProfessionContitionsOptional = Age =
                Treatments = Comments = ControlVisitDate = "";

            SelectedCLProfessionCondition = CLProfessionConditions.First();
            SelectedDistance = Distances.First();
            IsCarDriving = isComputerProfession = false;

            SetDates();
        }

        private void OnSubscribePersonDataRequestEvent()
            => eventAggregator.GetEvent<PersonDataResponseEvent>().Publish(this);
    }
}
