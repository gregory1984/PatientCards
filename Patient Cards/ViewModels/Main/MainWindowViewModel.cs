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
                    .GetEvent<Events.PersonalData.PersonDataResponseEvent>()
                    .Subscribe(vm => completionGuard.PersonData = vm);

                personDataResponseEventToken_GLCurrentCorrection = eventAggregator
                    .GetEvent<Events.GLCurrentCorrection.PersonDataResponseEvent>()
                    .Subscribe(vm => completionGuard.GLCurrentCorrection = vm);

                personDataResponseEventToken_GLMatchedCorrection = eventAggregator
                    .GetEvent<Events.GLMatchedCorrection.PersonDataResponseEvent>()
                    .Subscribe(vm => completionGuard.GLMatchedCorrection = vm);

                personDataResponseEventToken_CLCurrentCorrection = eventAggregator
                    .GetEvent<Events.CLCurrentCorrection.PersonDataResponseEvent>()
                    .Subscribe(vm => completionGuard.CLCurrentCorrection = vm);

                personDataResponseEventToken_CLMatchedCorrection = eventAggregator
                    .GetEvent<Events.CLMatchedCorrection.PersonDataResponseEvent>()
                    .Subscribe(vm => completionGuard.CLMatchedCorrection = vm);

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

            eventAggregator.GetEvent<Events.PersonalData.PersonDataResponseEvent>().Unsubscribe(personDataResponseEventToken_PersonData);
            eventAggregator.GetEvent<Events.GLCurrentCorrection.PersonDataResponseEvent>().Unsubscribe(personDataResponseEventToken_GLCurrentCorrection);
            eventAggregator.GetEvent<Events.GLMatchedCorrection.PersonDataResponseEvent>().Unsubscribe(personDataResponseEventToken_GLMatchedCorrection);
            eventAggregator.GetEvent<Events.CLCurrentCorrection.PersonDataResponseEvent>().Unsubscribe(personDataResponseEventToken_CLCurrentCorrection);
            eventAggregator.GetEvent<Events.CLMatchedCorrection.PersonDataResponseEvent>().Unsubscribe(personDataResponseEventToken_CLMatchedCorrection);
        }
        #endregion PERSON TESTING
    }
}
