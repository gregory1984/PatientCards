using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.DTO.CL
{
    public class CLCurrentCorrectionInterviewDTO
    {
        public int Id { get; set; }
        public string FromWhen { get; set; }
        public decimal? VisusBothEyes { get; set; }
        public IList<CLCurrentCorrectionDTO> CLCurrentCorrections { get; set; }
        public IList<CardDTO> Cards { get; set; }

        public CLCurrentCorrectionInterviewDTO() { }

        public CLCurrentCorrectionInterviewDTO(int id, string fromWhen, decimal? visusBothEyes, IList<CLCurrentCorrectionDTO> cLCurrentCorrections, IList<CardDTO> cards)
        {
            Id = id;
            FromWhen = fromWhen;
            VisusBothEyes = visusBothEyes;
            CLCurrentCorrections = cLCurrentCorrections;
            Cards = cards;
        }
    }
}
