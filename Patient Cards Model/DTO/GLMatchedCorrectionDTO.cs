using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.DTO
{
    public class GLMatchedCorrectionDTO
    {
        public int? Id { get; set; }
        public decimal? Sphere { get; set; }
        public decimal? Cylinder { get; set; }
        public int? Axis { get; set; }
        public decimal? Addition { get; set; }
        public decimal? Prism { get; set; }
        public int? BaseId { get; set; }
        public string BaseName { get; set; }
        public int EyeId { get; set; }
        public string EyeName { get; set; }
        public int? CardId { get; set; }
        public int GLMatchedCorrectionTypeId { get; set; }

        public GLMatchedCorrectionDTO() { }

        public GLMatchedCorrectionDTO(int? id, decimal? sphere, decimal? cylinder, int? axis, decimal? addition,
            decimal? prism, int? baseId, string baseName, int eyeId, string eyeName, int? cardId, int gLMatchedCorrectionTypeId)
        {
            Id = id;
            Sphere = sphere;
            Cylinder = cylinder;
            Axis = axis;
            Addition = addition;
            Prism = prism;
            BaseId = baseId;
            BaseName = baseName;
            EyeId = eyeId;
            EyeName = eyeName;
            CardId = cardId;
            GLMatchedCorrectionTypeId = gLMatchedCorrectionTypeId;
        }
    }
}
