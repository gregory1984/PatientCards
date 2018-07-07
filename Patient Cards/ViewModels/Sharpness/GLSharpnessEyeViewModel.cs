using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Patient_Cards.Helpers;
using Patient_Cards_Model.DTO.GL;

namespace Patient_Cards.ViewModels.Sharpness
{
    public class GLSharpnessEyeViewModel : BindableBase
    {
        public int EyeId { get; set; }
        public string EyeName { get; set; }
        public int? CardId { get; set; }

        private string currentCorrection = "";
        public string CurrentCorrection
        {
            get { return currentCorrection; }
            set { SetProperty(ref currentCorrection, value); }
        }

        private string sC = "";
        public string SC
        {
            get { return sC; }
            set { SetProperty(ref sC, value); }
        }

        private string cC = "";
        public string CC
        {
            get { return cC; }
            set { SetProperty(ref cC, value); }
        }

        public GLSharpnessEyeViewModel(GLSharpnessDTO dto)
        {
            EyeId = dto.EyeId;
            EyeName = dto.EyeName;
            CardId = dto.CardId;
            CurrentCorrection = dto.CurrentCorrection.FromOpticalSharpness();
            SC = dto.SC.FromOpticalSharpness();
            CC = dto.CC.FromOpticalSharpness();
        }
    }
}
