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

namespace Patient_Cards.ViewModels.Main
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Enums
        private enum VisibleSetup
        {
            GL,
            CL
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

        #endregion

        private readonly IDatabaseService databaseService;

        public MainWindowViewModel(IEventAggregator eventAggregator, IUnityContainer unityContainer, IDatabaseService databaseService, IDictionariesService dictionariesService)
            : base(eventAggregator, unityContainer, dictionariesService)
        {
            this.databaseService = databaseService;
        }

        private DelegateCommand loaded;
        public DelegateCommand Loaded
        {
            get => loaded ?? (loaded = new DelegateCommand(() =>
            {
                eventAggregator.ExecuteSafety(() =>
                {
                    SubscribeExceptionHandling();
                    SwitchSetupTab(VisibleSetup.GL);
                    databaseService.Initialize();
                });
            }));
        }

        private DelegateCommand showGLSetup;
        public DelegateCommand ShowGLSetup
        {
            get => showGLSetup ?? (showGLSetup = new DelegateCommand(() => SwitchSetupTab(VisibleSetup.GL)));
        }

        private DelegateCommand showCLSetup;
        public DelegateCommand ShowCLSetup
        {
            get => showCLSetup ?? (showCLSetup = new DelegateCommand(() => SwitchSetupTab(VisibleSetup.CL)));
        }

        private void SwitchSetupTab(VisibleSetup setup)
        {
            switch (setup)
            {
                case VisibleSetup.GL:
                    GLSetupVisibility = Visibility.Visible;
                    CLSetupVisibility = Visibility.Collapsed;
                    GLTabHeaderBackground = StaticNames.ActiveTabBackground;
                    CLTabHeaderBackground = StaticNames.InactiveTabBackground;
                    break;
                case VisibleSetup.CL:
                    GLSetupVisibility = Visibility.Collapsed;
                    CLSetupVisibility = Visibility.Visible;
                    GLTabHeaderBackground = StaticNames.InactiveTabBackground;
                    CLTabHeaderBackground = StaticNames.ActiveTabBackground;
                    break;
            }
        }
    }
}
