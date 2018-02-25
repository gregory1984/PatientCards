using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.DTO
{
    public class CLCurrentCorrectionDTO
    {
        public int? Id { get; set; }
        public decimal? Sphere { get; set; }
        public decimal? Cylinder { get; set; }
        public int? Axis { get; set; }
        public decimal? Addition { get; set; }
        public decimal? BC { get; set; }
        public decimal? Visus { get; set; }
        public int EyeId { get; set; }
        public string EyeName { get; set; }
        public int? CardId { get; set; }

        public CLCurrentCorrectionDTO() { }

        public CLCurrentCorrectionDTO(int? id, decimal? sphere, decimal? cylinder, int? axis, decimal? addition, decimal? bC, decimal? visus, int eyeId, string eyeName, int? cardId)
        {
            Id = id;
            Sphere = sphere;
            Cylinder = cylinder;
            Axis = axis;
            Addition = addition;
            BC = bC;
            Visus = visus;
            EyeId = eyeId;
            EyeName = eyeName;
            CardId = cardId;
        }
    }
}
