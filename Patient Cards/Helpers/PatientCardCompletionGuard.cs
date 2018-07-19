using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Cards.ViewModels.Corrections.CL;
using Patient_Cards.ViewModels.Corrections.GL;
using Patient_Cards.ViewModels.Dictionaries;
using Patient_Cards.ViewModels.Main;
using Patient_Cards.ViewModels.Rates;
using Patient_Cards.ViewModels.Sharpness;

namespace Patient_Cards.Helpers
{
    public class PatientCardCompletionGuard
    {
        public delegate void SaveReadyDelegate();
        public event SaveReadyDelegate SaveReadyEvent;

        private PersonalDataViewModel personData;
        public PersonalDataViewModel PersonData
        {
            get { return personData; }
            set
            {
                personData = value;
                FireSaveReadyEvent();
            }
        }

        private CLCurrentCorrectionViewModel cLCurrentCorrection;
        public CLCurrentCorrectionViewModel CLCurrentCorrection
        {
            get { return cLCurrentCorrection; }
            set
            {
                cLCurrentCorrection = value;
                FireSaveReadyEvent();
            }
        }

        private CLMatchedCorrectionViewModel cLMatchedCorrection;
        public CLMatchedCorrectionViewModel CLMatchedCorrection
        {
            get { return cLMatchedCorrection; }
            set
            {
                cLMatchedCorrection = value;
                FireSaveReadyEvent();
            }
        }

        private GLCurrentCorrectionViewModel gLCurrentCorrection;
        public GLCurrentCorrectionViewModel GLCurrentCorrection
        {
            get { return gLCurrentCorrection; }
            set
            {
                gLCurrentCorrection = value;
                FireSaveReadyEvent();
            }
        }

        private GLMatchedCorrectionViewModel gLMatchedCorrection;
        public GLMatchedCorrectionViewModel GLMatchedCorrection
        {
            get { return gLMatchedCorrection; }
            set
            {
                gLMatchedCorrection = value;
                FireSaveReadyEvent();
            }
        }

        private ComplaintsViewModel complaints;
        public ComplaintsViewModel Complaints
        {
            get { return complaints; }
            set
            {
                complaints = value;
                FireSaveReadyEvent();
            }
        }

        private IllnessesViewModel illnesses;
        public IllnessesViewModel Illnesses
        {
            get { return illnesses; }
            set
            {
                illnesses = value;
                FireSaveReadyEvent();
            }
        }

        private MedicamentsViewModel medicaments;
        public MedicamentsViewModel Medicaments
        {
            get { return medicaments; }
            set
            {
                medicaments = value;
                FireSaveReadyEvent();
            }
        }

        private OthersViewModel others;
        public OthersViewModel Others
        {
            get { return others; }
            set
            {
                others = value;
                FireSaveReadyEvent();
            }
        }

        private CLFrontEyeSectionRateViewModel cLFrontEyeSectionRate;
        public CLFrontEyeSectionRateViewModel CLFrontEyeSectionRate
        {
            get { return cLFrontEyeSectionRate; }
            set
            {
                cLFrontEyeSectionRate = value;
                FireSaveReadyEvent();
            }
        }

        private CLMatchedCorrectionRateViewModel cLMatchedCorrectionRate;
        public CLMatchedCorrectionRateViewModel CLMatchedCorrectionRate
        {
            get { return cLMatchedCorrectionRate; }
            set
            {
                cLMatchedCorrectionRate = value;
                FireSaveReadyEvent();
            }
        }

        private CLSharpnessViewModel cLSharpness;
        public CLSharpnessViewModel CLSharpness
        {
            get { return cLSharpness; }
            set
            {
                cLSharpness = value;
                FireSaveReadyEvent();
            }
        }

        private GLSharpnessViewModel gLSharpness;
        public GLSharpnessViewModel GLSharpness
        {
            get { return gLSharpness; }
            set
            {
                gLSharpness = value;
                FireSaveReadyEvent();
            }
        }

        private bool IsFilled()
        {
            return
                CLCurrentCorrection != null &&
                CLMatchedCorrection != null &&
                GLCurrentCorrection != null &&
                GLMatchedCorrection != null &&
                Complaints != null &&
                Illnesses != null &&
                Medicaments != null &&
                Others != null &&
                CLFrontEyeSectionRate != null &&
                CLMatchedCorrectionRate != null &&
                CLSharpness != null &&
                GLSharpness != null &&
                PersonData != null;
        }


        private void FireSaveReadyEvent()
        {
            if (IsFilled())
            {
                SaveReadyEvent?.Invoke();
            }

        }

        public void Clear()
        {
            CLCurrentCorrection = null;
            CLMatchedCorrection = null;
            GLCurrentCorrection = null;
            GLMatchedCorrection = null;
            Complaints = null;
            Illnesses = null;
            Medicaments = null;
            Others = null;
            CLFrontEyeSectionRate = null;
            CLMatchedCorrectionRate = null;
            CLSharpness = null;
            GLSharpness = null;
            PersonData = null;
        }
    }
}
