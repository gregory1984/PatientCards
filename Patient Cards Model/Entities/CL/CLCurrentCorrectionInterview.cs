﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.Entities.CL
{
    public class CLCurrentCorrectionInterview
    {
        public virtual int Id { get; set; }
        public virtual string FromWhen { get; set; }
        public virtual decimal? VisusBothEyes { get; set; }
        public virtual IList<CLCurrentCorrection> CLCurrentCorrections { get; set; }
        public virtual IList<Card> Cards { get; set; }
    }
}
