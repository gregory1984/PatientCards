using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities.CL;

namespace Patient_Cards_Model.Mappings.CL
{
    public class CLFrontEyeSectionRateMap : ClassMap<CLFrontEyeSectionRate>
    {
        public CLFrontEyeSectionRateMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.ControlVisitRate).Nullable().Length(1000);
            Map(x => x.CurrentVisitRate).Nullable().Length(1000);

            References(x => x.CLFrontEyeSectionRateInterview);
            References(x => x.CLFrontEyeSectionRateIssue);
        }
    }
}
