using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities.CL;

namespace Patient_Cards_Model.Mappings.CL
{
    public class CLMatchedCorrectionMap : ClassMap<CLMatchedCorrection>
    {
        public CLMatchedCorrectionMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.Sphere).Nullable();
            Map(x => x.Cylinder).Nullable();
            Map(x => x.Axis).Nullable();
            Map(x => x.Addition).Nullable();
            Map(x => x.BC).Nullable();
            Map(x => x.DIA).Nullable();

            References(x => x.CLMatchedCorrectionType);
            References(x => x.Eye);
            References(x => x.Card);
        }
    }
}
