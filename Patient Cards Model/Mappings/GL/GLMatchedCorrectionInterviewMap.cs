using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities.GL;

namespace Patient_Cards_Model.Mappings.GL
{
    public class GLMatchedCorrectionInterviewMap : ClassMap<GLMatchedCorrectionInterview>
    {
        public GLMatchedCorrectionInterviewMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.GLFinallyMatchedCorrectionTypeOptionals).Nullable().Length(1000);

            References(x => x.GLFinallyMatchedCorrectionType);

            HasMany(x => x.GLMatchedCorrections).Inverse().Cascade.All();
            HasMany(x => x.Cards).Inverse().Cascade.All();
        }
    }
}
