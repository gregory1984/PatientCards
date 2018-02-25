﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.DTO
{
    public class GLFinallyMatchedCorrectionTypeDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public GLFinallyMatchedCorrectionTypeDTO() { }

        public GLFinallyMatchedCorrectionTypeDTO(int? id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
