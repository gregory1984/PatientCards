﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.Entities.GL
{
    public class GLFinallyMatchedCorrectionType
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<GLMatchedCorrectionInterview> GLMatchedCorrectionInterviews { get; set; }
    }
}
