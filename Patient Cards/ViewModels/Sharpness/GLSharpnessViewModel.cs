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
using Patient_Cards_Model.Interfaces;
using Patient_Cards_Model.DTO.GL;

namespace Patient_Cards.ViewModels.Sharpness
{
    public class GLSharpnessViewModel : ViewModelBase
    {
        #region Properties
        private IList<GLSharpnessEyeViewModel> sharpnesses;
        public IList<GLSharpnessEyeViewModel> Sharpnesses
        {
            get { return sharpnesses; }
            set { SetProperty(ref sharpnesses, value); }
        }

        private GLSharpnessEyeViewModel selectedSharpness;
        public GLSharpnessEyeViewModel SelectedSharpness
        {
            get { return selectedSharpness; }
            set { SetProperty(ref selectedSharpness, value); }
        }
        #endregion

        private readonly ISharpnessService sharpnessService;

        public GLSharpnessViewModel(IEventAggregator eventAggregator, IUnityContainer unityContainer,
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
            Sharpnesses = new ObservableCollection<GLSharpnessEyeViewModel>();
            SelectedSharpness = null;

            foreach (GLSharpnessDTO s in sharpnessService.GetGLSharpnesses())
            {
                Sharpnesses.Add(new GLSharpnessEyeViewModel(s));
            }
        }
    }
}
