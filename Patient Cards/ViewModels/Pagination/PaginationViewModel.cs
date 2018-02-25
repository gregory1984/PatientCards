using Prism.Commands;
using Prism.Mvvm;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using Patient_Cards.Events.Pagination;
using Patient_Cards.Events.Payloads;
using Patient_Cards_Model.Interfaces;
using Patient_Cards_Model.DTO;

namespace Patient_Cards.ViewModels.Pagination
{
    public class PaginationViewModel : BindableBase
    {
        #region Properties
        private int pageNo = 1;
        public int PageNo
        {
            get { return pageNo; }
            set
            {
                SetProperty(ref pageNo, value);

                FirstPage.RaiseCanExecuteChanged();
                PreviousPage.RaiseCanExecuteChanged();
                NextPage.RaiseCanExecuteChanged();
                LastPage.RaiseCanExecuteChanged();
            }
        }

        private int pageCount = 1;
        public int PageCount
        {
            get { return pageCount; }
            set
            {
                SetProperty(ref pageCount, value);

                NextPage.RaiseCanExecuteChanged();
                LastPage.RaiseCanExecuteChanged();
            }
        }

        public int PageSize
        {
            get => preferencesService.Preferences.PatientsPerPage;
        }

        public string UserControlName { get; private set; }
        #endregion

        private readonly IEventAggregator eventAggregator;
        private readonly IPreferencesService preferencesService;

        public PaginationViewModel(string controlName, IEventAggregator eventAggregator, IPreferencesService preferencesService)
        {
            this.eventAggregator = eventAggregator;
            this.preferencesService = preferencesService;
        }

        private DelegateCommand firstPage;
        public DelegateCommand FirstPage
        {
            get => firstPage ?? (firstPage = new DelegateCommand(() =>
            {
                PageNo = 1;
                eventAggregator.GetEvent<JumpToPageEvent>().Publish(new JumpToPagePayload { No = PageNo, UserControlName = this.UserControlName });
            },

            () => PageNo > 1));
        }

        private DelegateCommand previousPage;
        public DelegateCommand PreviousPage
        {
            get => previousPage ?? (previousPage = new DelegateCommand(() =>
            {
                PageNo -= 1;
                eventAggregator.GetEvent<JumpToPageEvent>().Publish(new JumpToPagePayload { No = PageNo, UserControlName = this.UserControlName });
            },

            () => PageNo > 1));
        }

        private DelegateCommand nextPage;
        public DelegateCommand NextPage
        {
            get => nextPage ?? (nextPage = new DelegateCommand(() =>
            {
                PageNo += 1;
                eventAggregator.GetEvent<JumpToPageEvent>().Publish(new JumpToPagePayload { No = PageNo, UserControlName = this.UserControlName });
            },

            () => PageNo < PageCount));
        }

        private DelegateCommand lastPage;
        public DelegateCommand LastPage
        {
            get => lastPage ?? (lastPage = new DelegateCommand(() =>
            {
                PageNo = PageCount;
                eventAggregator.GetEvent<JumpToPageEvent>().Publish(new JumpToPagePayload { No = PageNo, UserControlName = this.UserControlName });
            },

            () => PageNo < PageCount));
        }
    }
}
