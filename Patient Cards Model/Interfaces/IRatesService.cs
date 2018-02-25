using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Cards_Model.DTO;

namespace Patient_Cards_Model.Interfaces
{
    public interface IRatesService
    {
        IList<CLFrontEyeSectionRateDTO> GetCLFrontEyeSectionRates(int? cardId = null);
        IList<CLMatchedCorrectionRateDTO> GetCLMatchedCorrectionRates(int? cardId = null);
    }
}
