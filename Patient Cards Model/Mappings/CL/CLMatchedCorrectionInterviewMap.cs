using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities.CL;

namespace Patient_Cards_Model.Mappings.CL
{
    public class CLMatchedCorrectionInterviewMap : ClassMap<CLMatchedCorrectionInterview>
    {
        public CLMatchedCorrectionInterviewMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();

            References(x => x.CLWearingTypeTest);
            References(x => x.CLPrimaryDataTest);
            References(x => x.CLWearingTypeTrade);
            References(x => x.CLPrimaryDataTrade);

            HasMany(x => x.CLMatchedCorrections).Inverse().Cascade.All();
            HasMany(x => x.Cards).Inverse().Cascade.All();
        }
    }
}
