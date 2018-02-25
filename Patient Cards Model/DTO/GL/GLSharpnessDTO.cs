using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.DTO.GL
{
    public class GLSharpnessDTO
    {
        public int? Id { get; set; }
        public int EyeId { get; set; }
        public string EyeName { get; set; }
        public int? CardId { get; set; }
        public decimal? CurrentCorrection { get; set; }
        public decimal? SC { get; set; }
        public decimal? CC { get; set; }

        public GLSharpnessDTO() { }

        public GLSharpnessDTO(int? id, int eyeId, string eyeName, int? cardId, decimal? currentCorrection, decimal? sC, decimal? cC)
        {
            Id = id;
            EyeId = eyeId;
            EyeName = eyeName;
            CardId = cardId;
            CurrentCorrection = currentCorrection;
            SC = sC;
            CC = cC;
        }
    }
}
