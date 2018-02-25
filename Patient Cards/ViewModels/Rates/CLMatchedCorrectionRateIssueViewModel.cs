using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Cards_Model.DTO.CL;

namespace Patient_Cards.ViewModels.Rates
{
    public class CLMatchedCorrectionRateIssueViewModel : BindableBase
    {
        public int? Id { get; set; }

        private string currentVisitRate;
        public string CurrentVisitRate
        {
            get { return currentVisitRate; }
            set { SetProperty(ref currentVisitRate, value); }
        }

        private string controlVisitRate;
        public string ControlVisitRate
        {
            get { return controlVisitRate; }
            set { SetProperty(ref controlVisitRate, value); }
        }

        public int? CardId { get; set; }
        public int IssueId { get; set; }
        public string IssueName { get; set; }

        public CLMatchedCorrectionRateIssueViewModel(CLMatchedCorrectionRateDTO dto)
        {
            Id = dto.Id;
            CurrentVisitRate = dto.CurrentVisitRate;
            ControlVisitRate = dto.ControlVisitRate;
            CardId = dto.CardId;
            IssueId = dto.CLMatchedCorrectionRateId;
            IssueName = dto.CLMatchedCorrectionRateName;
        }
    }
}
