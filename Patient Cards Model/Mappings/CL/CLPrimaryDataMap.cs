using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities.CL;

namespace Patient_Cards_Model.Mappings.CL
{
    public class CLPrimaryDataMap : ClassMap<CLPrimaryData>
    {
        public CLPrimaryDataMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.Name).Nullable().Length(1000);
            Map(x => x.Vendor).Nullable().Length(1000);
            Map(x => x.Liquid).Nullable().Length(1000);

            References(x => x.CLMatchedCorrectionInterviewTest);
            References(x => x.CLMatchedCorrectionInterviewTrade);
        }
    }
}
