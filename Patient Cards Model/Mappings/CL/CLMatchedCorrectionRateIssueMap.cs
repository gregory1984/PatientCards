using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities.CL;

namespace Patient_Cards_Model.Mappings.CL
{
    public class CLMatchedCorrectionRateIssueMap : ClassMap<CLMatchedCorrectionRateIssue>
    {
        public CLMatchedCorrectionRateIssueMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.Name).Not.Nullable().Length(1000);

            HasMany(x => x.CLMatchedCorrectionRates).Inverse().Cascade.SaveUpdate();
        }
    }
}
