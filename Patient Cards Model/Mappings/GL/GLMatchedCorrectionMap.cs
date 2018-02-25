using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities.GL;

namespace Patient_Cards_Model.Mappings.GL
{
    public class GLMatchedCorrectionMap : ClassMap<GLMatchedCorrection>
    {
        public GLMatchedCorrectionMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.Sphere).Nullable();
            Map(x => x.Cylinder).Nullable();
            Map(x => x.Axis).Nullable();
            Map(x => x.Addition).Nullable();
            Map(x => x.Prism).Nullable();

            References(x => x.GLMatchedCorrectionType);
            References(x => x.Base);
            References(x => x.Eye);
            References(x => x.Card);
        }
    }
}
