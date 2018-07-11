using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Cards.ViewModels.Corrections.CL;

namespace Patient_Cards.Events.Payloads.CLCurrentCorrection
{
    public class PersonDataPayload
    {
        public string FromWhen { get; set; }
        public decimal? VisusBothEyes { get; set; }
        public IList<CLCurrentCorrectionEyeViewModel> Corrections { get; set; }

        public PersonDataPayload(CLCurrentCorrectionViewModel vm)
        {
            FromWhen = vm.FromWhen;
            VisusBothEyes = vm.VisusBothEyes;
            Corrections = new List<CLCurrentCorrectionEyeViewModel>(vm.Corrections);
        }
    }
}
