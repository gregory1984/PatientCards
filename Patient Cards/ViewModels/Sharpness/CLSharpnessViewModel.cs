using Prism.Commands;
using Prism.Mvvm;
using Prism.Events;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using Patient_Cards.Helpers;
using Patient_Cards_Model.Interfaces;
using Patient_Cards.ViewModels.Base;
using Patient_Cards_Model.DTO.CL;

namespace Patient_Cards.ViewModels.Sharpness
{
    public class CLSharpnessViewModel : ViewModelBase
    {
        #region Properties
        private IList<CLSharpnessEyeViewModel> sharpnesses;
        public IList<CLSharpnessEyeViewModel> Sharpnesses
        {
            get { return sharpnesses; }
            set { SetProperty(ref sharpnesses, value); }
        }

        private CLSharpnessEyeViewModel selectedSharpness;
        public CLSharpnessEyeViewModel SelectedSharpness
        {
            get { return selectedSharpness; }
            set { SetProperty(ref selectedSharpness, value); }
        }
        #endregion

        private readonly ISharpnessService sharpnessService;

        public CLSharpnessViewModel(IEventAggregator eventAggregator, IUnityContainer unityContainer, 
                                    ISharpnessService sharpnessService, IDictionariesService dictionariesService)
            : base(eventAggregator, unityContainer, dictionariesService)
        {
            this.sharpnessService = sharpnessService;
        }

        private DelegateCommand loaded;
        public DelegateCommand Loaded
        {
            get => loaded ?? (loaded = new DelegateCommand(() =>
            {
                eventAggregator.ExecuteSafety(() =>
                {
                    GetSharpnesses();
                });
            }));
        }

        private void GetSharpnesses()
        {
            Sharpnesses = new ObservableCollection<CLSharpnessEyeViewModel>();
            SelectedSharpness = null;

            foreach (CLSharpnessDTO s in sharpnessService.GetCLSharpnesses())
            {
                Sharpnesses.Add(new CLSharpnessEyeViewModel(s));
            }
        }
    }
}
