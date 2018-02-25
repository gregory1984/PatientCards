using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Patient_Cards_Model.DTO.CL;

namespace Patient_Cards.ViewModels.Sharpness
{
    public class CLSharpnessEyeViewModel : BindableBase
    {
        public int EyeId { get; set; }
        public string EyeName { get; set; }
        public int? CardId { get; set; }

        private decimal? currentCorrection;
        public decimal? CurrentCorrection
        {
            get { return currentCorrection; }
            set { SetProperty(ref currentCorrection, value); }
        }

        private decimal? cC;
        public decimal? CC
        {
            get { return cC; }
            set { SetProperty(ref cC, value); }
        }

        public CLSharpnessEyeViewModel(CLSharpnessDTO dto)
        {
            EyeId = dto.EyeId;
            EyeName = dto.EyeName;
            CardId = dto.CardId;
            CurrentCorrection = dto.CurrentCorrection;
            CC = dto.CC;
        }
    }
}
