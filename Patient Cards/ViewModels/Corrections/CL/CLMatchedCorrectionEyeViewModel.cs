using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Patient_Cards.Helpers;
using Patient_Cards_Model.DTO.CL;
using Patient_Cards_Model.Interfaces;

namespace Patient_Cards.ViewModels.Corrections.CL
{
    public class CLMatchedCorrectionEyeViewModel : BindableBase
    {
        public int? Id { get; set; }
        public int EyeId { get; set; }
        public string EyeName { get; set; }
        public int? CardId { get; set; }
        private string sphere;
        public string Sphere
        {
            get { return sphere; }
            set { SetProperty(ref sphere, value); }
        }

        private string cylinder;
        public string Cylinder
        {
            get { return cylinder; }
            set { SetProperty(ref cylinder, value); }
        }

        private string axis;
        public string Axis
        {
            get { return axis; }
            set { SetProperty(ref axis, value); }
        }

        private string addition;
        public string Addition
        {
            get { return addition; }
            set { SetProperty(ref addition, value); }
        }

        private string bC;
        public string BC
        {
            get { return bC; }
            set { SetProperty(ref bC, value); }
        }

        private string dIA;
        public string DIA
        {
            get { return dIA; }
            set { SetProperty(ref dIA, value); }
        }

        public int CLMatchedCorrectionTypeId { get; set; }

        public CLMatchedCorrectionEyeViewModel(CLMatchedCorrectionDTO dto)
        {
            Id = dto.Id;
            Sphere = dto.Sphere.FromOpticalNumber();
            Cylinder = dto.Cylinder.FromOpticalNumber();
            Axis = dto.Axis.FromOpticalAxis();
            Addition = dto.Addition.FromOpticalNumber();
            BC = dto.BC.FromOpticalNumber();
            DIA = dto.DIA.FromOpticalNumber();
            EyeId = dto.EyeId;
            EyeName = dto.EyeName;
            CardId = dto.CardId;
            CLMatchedCorrectionTypeId = dto.CLMatchedCorrectionTypeId;
        }
    }
}
