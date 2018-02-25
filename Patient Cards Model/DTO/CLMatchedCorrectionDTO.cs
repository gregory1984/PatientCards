using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.DTO
{
    public class CLMatchedCorrectionDTO
    {
        public int? Id { get; set; }
        public decimal? Sphere { get; set; }
        public decimal? Cylinder { get; set; }
        public int? Axis { get; set; }
        public decimal? Addition { get; set; }
        public decimal? BC { get; set; }
        public decimal? DIA { get; set; }
        public int EyeId { get; set; }
        public string EyeName { get; set; }
        public int? CardId { get; set; }
        public int CLMatchedCorrectionTypeId { get; set; }

        public CLMatchedCorrectionDTO() { }

        public CLMatchedCorrectionDTO(int? id, decimal? sphere, decimal? cylinder, int? axis, decimal? addition,
            decimal? bC, decimal? dIA, int eyeId, string eyeName, int? cardId, int cLMatchedCorrectionTypeId)
        {
            Id = id;
            Sphere = sphere;
            Cylinder = cylinder;
            Axis = axis;
            Addition = addition;
            BC = bC;
            DIA = dIA;
            EyeId = eyeId;
            EyeName = eyeName;
            CardId = cardId;
            CLMatchedCorrectionTypeId = cLMatchedCorrectionTypeId;
        }
    }
}
