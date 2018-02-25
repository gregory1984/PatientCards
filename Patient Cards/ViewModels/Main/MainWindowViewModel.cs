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
        #region Properties

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
                    databaseService.Initialize();
                });
            }));
        }
    }
}
