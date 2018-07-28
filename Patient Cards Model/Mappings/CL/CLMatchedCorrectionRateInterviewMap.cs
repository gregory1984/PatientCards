using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities.CL;

namespace Patient_Cards_Model.Mappings.CL
{
    public class CLMatchedCorrectionRateInterviewMap : ClassMap<CLMatchedCorrectionRateInterview>
    {
        public CLMatchedCorrectionRateInterviewMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();

            HasMany(x => x.CLMatchedCorrectionRates).Inverse().Cascade.All();
            HasMany(x => x.Cards).Inverse().Cascade.All();
        }
    }
}
