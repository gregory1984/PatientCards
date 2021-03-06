﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities.GL;

namespace Patient_Cards_Model.Mappings.GL
{
    public class GLFinallyMatchedCorrectionTypeMap : ClassMap<GLFinallyMatchedCorrectionType>
    {
        public GLFinallyMatchedCorrectionTypeMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.Name).Not.Nullable().Length(1000);

            HasMany(x => x.GLMatchedCorrectionInterviews).Inverse().Cascade.SaveUpdate();
        }
    }
}
