using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Mvvm;
using Prism.Commands;
using Patient_Cards_Model.Interfaces;
using Patient_Cards.Helpers;
using Patient_Cards.ViewModels.Base;
using Patient_Cards.Events.PersonTest;


namespace Patient_Cards.ViewModels.Main
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Enums
        private enum VisibleRightTab
        {
            GL,
            CL
        }

        private enum VisibleLeftTab
        {
            Interview,
            Searching
        }
        #endregion

        #region Properties
        private Visibility gLSetupVisibility;
        public Visibility GLSetupVisibility
        {
            get { return gLSetupVisibility; }
            set { SetProperty(ref gLSetupVisibility, value); }
        }

        private Visibility cLSetupVisibility;
        public Visibility CLSetupVisibility
        {
            get { return cLSetupVisibility; }
            set { SetProperty(ref cLSetupVisibility, value); }
        }

        private Visibility interviewVisibility;
        public Visibility InterviewVisibility
        {
            get { return interviewVisibility; }
            set { SetProperty(ref interviewVisibility, value); }
        }

        private Visibility searchingVisibility;
        public Visibility SearchingVisibility
        {
            get { return searchingVisibility; }
            set { SetProperty(ref searchingVisibility, value); }
        }

        private string interviewTabHeaderBackground = "";
        public string InterviewTabHeaderBackground
        {
            get { return interviewTabHeaderBackground; }
            set { SetProperty(ref interviewTabHeaderBackground, value); }
        }

        private string searchingTabHeaderBackground = "";
        public string SearchingTabHeaderBackground
        {
            get { return searchingTabHeaderBackground; }
            set { SetProperty(ref searchingTabHeaderBackground, value); }
        }

        private string gLTabHeaderBackground = "";
        public string GLTabHeaderBackground
        {
            get { return gLTabHeaderBackground; }
            set { SetProperty(ref gLTabHeaderBackground, value); }
        }

        private string cLTabHeaderBackground = "";
        public string CLTabHeaderBackground
        {
            get { return cLTabHeaderBackground; }
            set { SetProperty(ref cLTabHeaderBackground, value); }
        }
        #endregion

        #region Delegates

        #endregion

        #region Event tokens
        private SubscriptionToken personDataResponseEventToken_PersonData;
        private SubscriptionToken personDataResponseEventToken_GLCurrentCorrection;
        private SubscriptionToken personDataResponseEventToken_GLMatchedCorrection;
        private SubscriptionToken personDataResponseEventToken_CLCurrentCorrection;
        private SubscriptionToken personDataResponseEventToken_CLMatchedCorrection;
        private SubscriptionToken personDataResponseEventToken_Complaints;
        private SubscriptionToken personDataResponseEventToken_Illnesses;
        private SubscriptionToken personDataResponseEventToken_Medicaments;
        private SubscriptionToken personDataResponseEventToken_Others;
        private SubscriptionToken personDataResponseEventToken_CLFrontEyeSectionRate;
        private SubscriptionToken personDataResponseEventToken_CLMatchedCorrectionRate;
        private SubscriptionToken personDataResponseEventToken_CLSharpness;
        private SubscriptionToken personDataResponseEventToken_GLSharpness;
        #endregion

        private readonly IDatabaseService databaseService;
        private PatientCardCompletionGuard completionGuard;

        public MainWindowViewModel(IEventAggregator eventAggregator, IUnityContainer unityContainer, IDatabaseService databaseService, IDictionariesService dictionariesService)
            : base(eventAggregator, unityContainer, dictionariesService)
        {
            this.databaseService = databaseService;
            this.completionGuard = new PatientCardCompletionGuard();
            this.completionGuard.SaveReadyEvent += SaveCard;
        }

        private DelegateCommand loaded;
        public DelegateCommand Loaded
        {
            get => loaded ?? (loaded = new DelegateCommand(() =>
            {
                personDataResponseEventToken_PersonData = eventAggregator
                    .GetEvent<Events.Main.PersonalData.PersonDataResponseEvent>()
                    .Subscribe(vm => completionGuard.PersonData = vm);

                personDataResponseEventToken_GLCurrentCorrection = eventAggregator
                    .GetEvent<Events.Corrections.GL.GLCurrentCorrection.PersonDataResponseEvent>()
                    .Subscribe(vm => completionGuard.GLCurrentCorrection = vm);

                personDataResponseEventToken_GLMatchedCorrection = eventAggregator
                    .GetEvent<Events.Corrections.GL.GLMatchedCorrection.PersonDataResponseEvent>()
                    .Subscribe(vm => completionGuard.GLMatchedCorrection = vm);

                personDataResponseEventToken_CLCurrentCorrection = eventAggregator
                    .GetEvent<Events.Corrections.CL.CLCurrentCorrection.PersonDataResponseEvent>()
                    .Subscribe(vm => completionGuard.CLCurrentCorrection = vm);

                personDataResponseEventToken_CLMatchedCorrection = eventAggregator
                    .GetEvent<Events.Corrections.CL.CLMatchedCorrection.PersonDataResponseEvent>()
                    .Subscribe(vm => completionGuard.CLMatchedCorrection = vm);

                personDataResponseEventToken_Complaints = eventAggregator
                    .GetEvent<Events.Dictionaries.Complaints.PersonDataResponseEvent>()
                    .Subscribe(vm => completionGuard.Complaints = vm);

                personDataResponseEventToken_Illnesses = eventAggregator
                    .GetEvent<Events.Dictionaries.Illnesses.PersonDataResponseEvent>()
                    .Subscribe(vm => completionGuard.Illnesses = vm);

                personDataResponseEventToken_Medicaments = eventAggregator
                    .GetEvent<Events.Dictionaries.Medicaments.PersonDataResponseEvent>()
                    .Subscribe(vm => completionGuard.Medicaments = vm);

                personDataResponseEventToken_Others = eventAggregator
                    .GetEvent<Events.Dictionaries.Others.PersonDataResponseEvent>()
                    .Subscribe(vm => completionGuard.Others = vm);

                personDataResponseEventToken_CLFrontEyeSectionRate = eventAggregator
                    .GetEvent<Events.Rates.CLFrontEyeSectionRate.PersonDataResponseEvent>()
                    .Subscribe(vm => completionGuard.CLFrontEyeSectionRate = vm);

                personDataResponseEventToken_CLMatchedCorrectionRate = eventAggregator
                    .GetEvent<Events.Rates.CLMatchedCorrectionRate.PersonDataResponseEvent>()
                    .Subscribe(vm => completionGuard.CLMatchedCorrectionRate = vm);

                personDataResponseEventToken_CLSharpness = eventAggregator
                    .GetEvent<Events.Sharpness.CLSharpness.PersonDataResponseEvent>()
                    .Subscribe(vm => completionGuard.CLSharpness = vm);

                personDataResponseEventToken_GLSharpness = eventAggregator
                    .GetEvent<Events.Sharpness.GLSharpness.PersonDataResponseEvent>()
                    .Subscribe(vm => completionGuard.GLSharpness = vm);

                eventAggregator.ExecuteSafety(() =>
                {
                    SubscribeExceptionHandling();
                    SwitchLeftSideTab(VisibleLeftTab.Interview);
                    SwitchRightSideTab(VisibleRightTab.GL);
                    databaseService.Initialize();
                });
            }));
        }

        private DelegateCommand showInterview;
        public DelegateCommand ShowInterview
        {
            get => showInterview ?? (showInterview = new DelegateCommand(() => SwitchLeftSideTab(VisibleLeftTab.Interview)));
        }

        private DelegateCommand showSearching;
        public DelegateCommand ShowSearching
        {
            get => showSearching ?? (showSearching = new DelegateCommand(() => SwitchLeftSideTab(VisibleLeftTab.Searching)));
        }

        private DelegateCommand showGLSetup;
        public DelegateCommand ShowGLSetup
        {
            get => showGLSetup ?? (showGLSetup = new DelegateCommand(() => SwitchRightSideTab(VisibleRightTab.GL)));
        }

        private DelegateCommand showCLSetup;
        public DelegateCommand ShowCLSetup
        {
            get => showCLSetup ?? (showCLSetup = new DelegateCommand(() => SwitchRightSideTab(VisibleRightTab.CL)));
        }

        private void SwitchLeftSideTab(VisibleLeftTab tab)
        {
            switch (tab)
            {
                case VisibleLeftTab.Interview:
                    InterviewVisibility = Visibility.Visible;
                    SearchingVisibility = Visibility.Collapsed;
                    InterviewTabHeaderBackground = StaticNames.ActiveTabBackground;
                    SearchingTabHeaderBackground = StaticNames.InactiveTabBackground;
                    break;
                case VisibleLeftTab.Searching:
                    InterviewVisibility = Visibility.Collapsed;
                    SearchingVisibility = Visibility.Visible;
                    InterviewTabHeaderBackground = StaticNames.InactiveTabBackground;
                    SearchingTabHeaderBackground = StaticNames.ActiveTabBackground;
                    break;
            }
        }

        private void SwitchRightSideTab(VisibleRightTab tab)
        {
            switch (tab)
            {
                case VisibleRightTab.GL:
                    GLSetupVisibility = Visibility.Visible;
                    CLSetupVisibility = Visibility.Collapsed;
                    GLTabHeaderBackground = StaticNames.ActiveTabBackground;
                    CLTabHeaderBackground = StaticNames.InactiveTabBackground;
                    break;
                case VisibleRightTab.CL:
                    GLSetupVisibility = Visibility.Collapsed;
                    CLSetupVisibility = Visibility.Visible;
                    GLTabHeaderBackground = StaticNames.InactiveTabBackground;
                    CLTabHeaderBackground = StaticNames.ActiveTabBackground;
                    break;
            }
        }


        #region PERSON TESTING
        private string testSurname = "";
        public string TestSurname
        {
            get { return testSurname; }
            set { SetProperty(ref testSurname, value); }
        }

        private DelegateCommand loadLastSavedTestPerson;
        public DelegateCommand LoadLastSavedTestPerson
        {
            get => loadLastSavedTestPerson ?? (loadLastSavedTestPerson = new DelegateCommand(() =>
            {
                eventAggregator.ExecuteSafety(() =>
                {

                });
            }));
        }

        private DelegateCommand saveTestPerson;
        public DelegateCommand SaveTestPerson
        {
            get => saveTestPerson ?? (saveTestPerson = new DelegateCommand(() => eventAggregator.GetEvent<PersonDataRequestEvent>().Publish()));
        }

        private DelegateCommand clearForm;
        public DelegateCommand ClearForm
        {
            get => clearForm ?? (clearForm = new DelegateCommand(() =>
            {
                eventAggregator.ExecuteSafety(() =>
                {

                });
            }));
        }

        private DelegateCommand findTestPerson;
        public DelegateCommand FindTestPerson
        {
            get => findTestPerson ?? (findTestPerson = new DelegateCommand(() =>
            {
                eventAggregator.ExecuteSafety(() =>
                {

                });
            }));
        }

        private void SaveCard()
        {
            //  TODO:
            // 1. save to the database...

            completionGuard.Clear();
            eventAggregator.GetEvent<ClearFormEvent>().Publish();
        }

        public override void UnsubscribePrismEvents()
        {
            base.UnsubscribePrismEvents();

            eventAggregator.GetEvent<Events.Main.PersonalData.PersonDataResponseEvent>().Unsubscribe(personDataResponseEventToken_PersonData);
            eventAggregator.GetEvent<Events.Corrections.GL.GLCurrentCorrection.PersonDataResponseEvent>().Unsubscribe(personDataResponseEventToken_GLCurrentCorrection);
            eventAggregator.GetEvent<Events.Corrections.GL.GLMatchedCorrection.PersonDataResponseEvent>().Unsubscribe(personDataResponseEventToken_GLMatchedCorrection);
            eventAggregator.GetEvent<Events.Corrections.CL.CLCurrentCorrection.PersonDataResponseEvent>().Unsubscribe(personDataResponseEventToken_CLCurrentCorrection);
            eventAggregator.GetEvent<Events.Corrections.CL.CLMatchedCorrection.PersonDataResponseEvent>().Unsubscribe(personDataResponseEventToken_CLMatchedCorrection);
            eventAggregator.GetEvent<Events.Dictionaries.Complaints.PersonDataResponseEvent>().Unsubscribe(personDataResponseEventToken_Complaints);
            eventAggregator.GetEvent<Events.Dictionaries.Illnesses.PersonDataResponseEvent>().Unsubscribe(personDataResponseEventToken_Illnesses);
            eventAggregator.GetEvent<Events.Dictionaries.Medicaments.PersonDataResponseEvent>().Unsubscribe(personDataResponseEventToken_Medicaments);
            eventAggregator.GetEvent<Events.Dictionaries.Others.PersonDataResponseEvent>().Unsubscribe(personDataResponseEventToken_Others);
            eventAggregator.GetEvent<Events.Rates.CLFrontEyeSectionRate.PersonDataResponseEvent>().Unsubscribe(personDataResponseEventToken_CLFrontEyeSectionRate);
            eventAggregator.GetEvent<Events.Rates.CLMatchedCorrectionRate.PersonDataResponseEvent>().Unsubscribe(personDataResponseEventToken_CLMatchedCorrectionRate);
            eventAggregator.GetEvent<Events.Sharpness.CLSharpness.PersonDataResponseEvent>().Unsubscribe(personDataResponseEventToken_CLSharpness);
            eventAggregator.GetEvent<Events.Sharpness.GLSharpness.PersonDataResponseEvent>().Unsubscribe(personDataResponseEventToken_GLSharpness);
        }
        #endregion PERSON TESTING
    }
}
