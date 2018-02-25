using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities.CL;

namespace Patient_Cards_Model.Mappings.CL
{
    public class CLSharpnessMap : ClassMap<CLSharpness>
    {
        public CLSharpnessMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.CurrentCorrection).Nullable();
            Map(x => x.CC).Nullable();

            References(x => x.Card);
            References(x => x.Eye);
        }
    }
}
