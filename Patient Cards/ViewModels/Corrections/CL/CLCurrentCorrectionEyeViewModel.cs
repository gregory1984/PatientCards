using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Patient_Cards_Model.DTO;

namespace Patient_Cards.ViewModels.Corrections.CL
{
    public class CLCurrentCorrectionEyeViewModel : BindableBase
    {
        public int? Id { get; set; }
        public int EyeId { get; set; }
        public string EyeName { get; set; }
        public int? CardId { get; set; }

        private decimal? sphere;
        public decimal? Sphere
        {
            get { return sphere; }
            set { SetProperty(ref sphere, value); }
        }

        private decimal? cylinder;
        public decimal? Cylinder
        {
            get { return cylinder; }
            set { SetProperty(ref cylinder, value); }
        }

        private int? axis;
        public int? Axis
        {
            get { return axis; }
            set { SetProperty(ref axis, value); }
        }

        private decimal? addition;
        public decimal? Addition
        {
            get { return addition; }
            set { SetProperty(ref addition, value); }
        }

        private decimal? bC;
        public decimal? BC
        {
            get { return bC; }
            set { SetProperty(ref bC, value); }
        }

        private decimal? visus;
        public decimal? Visus
        {
            get { return visus; }
            set { SetProperty(ref visus, value); }
        }

        public CLCurrentCorrectionEyeViewModel(CLCurrentCorrectionDTO dto)
        {
            Id = dto.Id;
            EyeId = dto.EyeId;
            EyeName = dto.EyeName;
            CardId = dto.CardId;
            Sphere = dto.Sphere;
            Cylinder = dto.Cylinder;
            Axis = dto.Axis;
            Addition = dto.Addition;
            BC = dto.BC;
            Visus = dto.Visus;
        }
    }
}
