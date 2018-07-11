using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Cards.ViewModels.Corrections.GL;

namespace Patient_Cards.Events.Payloads.GLCurrentCorrection
{
    public class PersonDataPayload
    {
        public string FromWhen { get; set; }
        public string CurrentGLType { get; set; }
        public IList<GLCurrentCorrectionEyeViewModel> Corrections { get; set; }

        public PersonDataPayload(GLCurrentCorrectionViewModel vm)
        {
            FromWhen = vm.FromWhen;
            CurrentGLType = vm.CurrentGLType;
            Corrections = new List<GLCurrentCorrectionEyeViewModel>(vm.Corrections);
        }
    }
}
