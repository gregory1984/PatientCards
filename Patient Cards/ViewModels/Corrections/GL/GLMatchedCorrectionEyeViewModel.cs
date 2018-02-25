using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Patient_Cards_Model.DTO;
using Patient_Cards_Model.DTO.GL;
using Patient_Cards_Model.Interfaces;

namespace Patient_Cards.ViewModels.Corrections.GL
{
    public class GLMatchedCorrectionEyeViewModel : BindableBase
    {
        public int? Id { get; set; }
        public int EyeId { get; set; }
        public string EyeName { get; set; }
        public int? CardId { get; set; }

        private IList<BaseDTO> bases;
        public IList<BaseDTO> Bases
        {
            get { return bases; }
            set { SetProperty(ref bases, value); }
        }

        private BaseDTO selectedBase;
        public BaseDTO SelectedBase
        {
            get { return selectedBase; }
            set { SetProperty(ref selectedBase, value); }
        }

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

        private decimal? prism;
        public decimal? Prism
        {
            get { return prism; }
            set { SetProperty(ref prism, value); }
        }

        public int GLMatchedCorrectionTypeId { get; set; }

        public GLMatchedCorrectionEyeViewModel(GLMatchedCorrectionDTO dto, IDictionariesService dictionariesService)
        {
            Id = dto.Id;
            EyeId = dto.EyeId;
            EyeName = dto.EyeName;
            CardId = dto.CardId;
            Sphere = dto.Sphere;
            Cylinder = dto.Cylinder;
            Axis = dto.Axis;
            Addition = dto.Addition;
            Prism = dto.Prism;
            GLMatchedCorrectionTypeId = dto.GLMatchedCorrectionTypeId;

            Bases = new ObservableCollection<BaseDTO> { new BaseDTO { Id = null, Name = "-- Wybierz --" } };
            foreach (BaseDTO b in dictionariesService.Bases.Values)
            {
                Bases.Add(b);
            }
            SelectedBase = Bases.SingleOrDefault(b => b.Id == dto.BaseId);
        }
    }
}
