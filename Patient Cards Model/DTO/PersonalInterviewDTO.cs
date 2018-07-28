using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.DTO
{
    public class PersonalInterviewDTO
    {
        public int? Id { get; set; }
        public DateTime CurrentVisitDate { get; set; }
        public DateTime? PreviousVisitDate { get; set; }
        public string ControlVisitDate { get; set; }
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public int? PatientAge { get; set; }
        public string VisitCause { get; set; }
        public string ProfessionOrHobby { get; set; }
        public int DistanceId { get; set; }
        public bool IsComputerProfession { get; set; }
        public string ComputerProfessionOptionals { get; set; }
        public bool IsCarDriving { get; set; }
        public string CarDrivingOptionals { get; set; }
        public int CLProfessionConditionId { get; set; }
        public string CLProfessionConditionOptionals { get; set; }
        public string Treatments { get; set; }

        public PersonalInterviewDTO() { }

        public PersonalInterviewDTO(
            int? id, DateTime currentVisitDate, DateTime? previousVisitDate, string controlVisitDate,
            string patientId, string patientName, string patientSurname, int? patientAge, string visitCause,
            string professionOrHobby, int distanceId, bool isComputerProfession, string computerProfessionOptionals,
            bool isCarDriving, string carDrivingOptionals, int cLProfessionConditionId,
            string cLProfessionConditionOptionals, string treatments)
        {
            Id = id;
            CurrentVisitDate = currentVisitDate;
            PreviousVisitDate = previousVisitDate;
            ControlVisitDate = controlVisitDate;
            PatientId = patientId;
            PatientName = patientName;
            PatientSurname = patientSurname;
            PatientAge = patientAge;
            VisitCause = visitCause;
            ProfessionOrHobby = professionOrHobby;
            DistanceId = distanceId;
            IsComputerProfession = isComputerProfession;
            ComputerProfessionOptionals = computerProfessionOptionals;
            IsCarDriving = isCarDriving;
            CarDrivingOptionals = carDrivingOptionals;
            CLProfessionConditionId = cLProfessionConditionId;
            CLProfessionConditionOptionals = cLProfessionConditionOptionals;
            Treatments = treatments;
        }
    }
}
