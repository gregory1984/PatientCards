using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Cards.ViewModels.Base;
using Patient_Cards.ViewModels.Corrections.CL;
using Patient_Cards.ViewModels.Corrections.GL;
using Patient_Cards.ViewModels.Dictionaries;
using Patient_Cards.ViewModels.Main;
using Patient_Cards.ViewModels.Rates;
using Patient_Cards.ViewModels.Sharpness;

namespace Patient_Cards.Helpers
{
    public class PatientCardCollector
    {
        public delegate void FilledDelegate();
        public event FilledDelegate FilledEvent;

        private IDictionary<Type, ViewModelBase> container;

        public PatientCardCollector()
            => container = new Dictionary<Type, ViewModelBase>();

        public void AddViewModel(Type type, ViewModelBase obj)
        {
            container.Add(type, obj);

            if (IsFilled())
            {
                FilledEvent?.Invoke();
            }
        }

        public ViewModelBase GetViewModel(Type type)
            => container[type];

        private bool IsFilled()
        {
            return
                container.ContainsKey(typeof(PersonalDataViewModel)) &&
                container.ContainsKey(typeof(CLCurrentCorrectionViewModel)) &&
                container.ContainsKey(typeof(CLMatchedCorrectionViewModel)) &&
                container.ContainsKey(typeof(GLCurrentCorrectionViewModel)) &&
                container.ContainsKey(typeof(GLMatchedCorrectionViewModel)) &&
                container.ContainsKey(typeof(ComplaintsViewModel)) &&
                container.ContainsKey(typeof(IllnessesViewModel)) &&
                container.ContainsKey(typeof(MedicamentsViewModel)) &&
                container.ContainsKey(typeof(OthersViewModel)) &&
                container.ContainsKey(typeof(CLFrontEyeSectionRateViewModel)) &&
                container.ContainsKey(typeof(CLMatchedCorrectionRateViewModel)) &&
                container.ContainsKey(typeof(CLSharpnessViewModel)) &&
                container.ContainsKey(typeof(GLSharpnessViewModel));

        }

        public void Clear()
            => container.Clear();
    }
}
