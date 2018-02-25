using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities.GL;

namespace Patient_Cards_Model.Mappings.GL
{
    public class GLCurrentCorrectionMap : ClassMap<GLCurrentCorrection>
    {
        public GLCurrentCorrectionMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.Sphere).Nullable();
            Map(x => x.Cylinder).Nullable();
            Map(x => x.Axis).Nullable();
            Map(x => x.Prism).Nullable();
            Map(x => x.Addition).Nullable();

            References(x => x.Base).Nullable();
            References(x => x.Eye);
            References(x => x.Card);
        }
    }
}
