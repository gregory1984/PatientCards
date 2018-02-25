using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities.CL;

namespace Patient_Cards_Model.Mappings.CL
{
    public class CLMatchedCorrectionRateMap : ClassMap<CLMatchedCorrectionRate>
    {
        public CLMatchedCorrectionRateMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.CurrentVisitRate).Nullable().Length(1000);
            Map(x => x.ControlVisitRate).Nullable().Length(1000);

            References(x => x.Card);
            References(x => x.CLMatchedCorrectionRateIssue);
        }
    }
}
