using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.DTO.CL
{
    public class CLSharpnessDTO
    {
        public int? Id { get; set; }
        public int EyeId { get; set; }
        public string EyeName { get; set; }
        public int? CardId { get; set; }
        public decimal? CurrentCorrection { get; set; }
        public decimal? CC { get; set; }

        public CLSharpnessDTO() { }

        public CLSharpnessDTO(int? id, int eyeId, string eyeName, int? cardId, decimal? currentCorrection, decimal? cC)
        {
            Id = id;
            EyeId = eyeId;
            EyeName = eyeName;
            CardId = cardId;
            CurrentCorrection = currentCorrection;
            CC = cC;
        }
    }
}
