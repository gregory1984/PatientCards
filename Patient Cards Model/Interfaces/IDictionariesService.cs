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
    public enum DictionaryType
    {
        GLFinallyMatchedCorrectionTypes,
        CLWearingTypes,
        Bases,
        Complaints,
        Medicaments,
        Others,
        Illnesses,
        Distances,
        CLProfessionConditions
    }

    public interface IDictionariesService
    {
        IDictionary<int, GLFinallyMatchedCorrectionTypeDTO> GLFinallyMatchedCorrectionTypes { get; }
        IDictionary<int, CLWearingTypeDTO> CLWearingTypes { get; }
        IDictionary<int, BaseDTO> Bases { get; }
        IDictionary<int, ComplaintDTO> Complaints { get; }
        IDictionary<int, MedicamentDTO> Medicaments { get; }
        IDictionary<int, OtherDTO> Others { get; }
        IDictionary<int, IllnessDTO> Illnesses { get; }
        IDictionary<int, DistanceDTO> Distances { get; }
        IDictionary<int, CLProfessionConditionDTO> CLProfessionConditions { get; }
    }
}
