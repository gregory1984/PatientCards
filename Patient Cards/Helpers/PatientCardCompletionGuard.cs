using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Cards.ViewModels.Corrections.CL;
using Patient_Cards.ViewModels.Corrections.GL;
using Patient_Cards.ViewModels.Main;

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

        private bool IsFilled()
        {
            return
                CLCurrentCorrection != null &&
                CLMatchedCorrection != null &&
                GLCurrentCorrection != null &&
                GLMatchedCorrection != null &&
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
            PersonData = null;
        }
    }
}
