using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Cards_Model.DTO;
using Patient_Cards_Model.DTO.CL;
using Patient_Cards_Model.DTO.GL;

namespace Patient_Cards_Model.Interfaces
{
    public enum GLCorrectionType
    {
        FromPhoropter = 1,
        FinallyMatched = 2
    }

    public enum CLCorrectionType
    {
        ForTesting = 1,
        ForTrading = 2,
    }

    public enum VisionType
    {
        GL = 1,
        CL = 2
    }

    public interface ICorrectionService
    {
        IList<GLMatchedCorrectionDTO> GetGLMatchedCorrections(GLCorrectionType gLCorrectionType, int? cardId = null);
        IList<CLMatchedCorrectionDTO> GetCLMatchedCorrections(CLCorrectionType cLCorrectionType, int? cardId = null);
        IList<CLPrimaryDataDTO> GetCLPrimaryDatas(int cardId);
        IList<GLCurrentCorrectionDTO> GetGLCurrentCorrections(int? cardId = null);
        IList<CLCurrentCorrectionDTO> GetCLCurrentCorrections(int? cardId = null);
        string GetCurrentCorrectionFromWhen(VisionType visionType, int cardId);
    }
}
