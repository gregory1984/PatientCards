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
using Patient_Cards_Model.DTO.CL;

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

        private int age;
        public int Age
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

        private string currentGLType = "";
        public string CurrentGLType
        {
            get { return currentGLType; }
            set { SetProperty(ref currentGLType, value); }
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
                eventAggregator.ExecuteSafety(() =>
                {
                    GetDistances();
                    GetCLProfessionConditions();
                });
            }));
        }

        private void GetDistances()
        {
            Distances = new ObservableCollection<DistanceDTO> { new DistanceDTO { Id = null, Name = "-- Wybierz --" } };
            foreach (DistanceDTO d in dictionariesService.Distances.Values)
            {
                distances.Add(d);
            }
            SelectedDistance = Distances.First();
        }

        private void GetCLProfessionConditions()
        {
            CLProfessionConditions = new ObservableCollection<CLProfessionConditionDTO> { new CLProfessionConditionDTO { Id = null, Name = "-- Wybierz --" } };
            foreach (CLProfessionConditionDTO d in dictionariesService.CLProfessionConditions.Values)
            {
                CLProfessionConditions.Add(d);
            }
            SelectedCLProfessionCondition = CLProfessionConditions.First();
        }
    }
}
