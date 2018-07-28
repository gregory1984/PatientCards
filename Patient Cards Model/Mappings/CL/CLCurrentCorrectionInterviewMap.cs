using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities.CL;

namespace Patient_Cards_Model.Mappings.CL
{
    public class CLCurrentCorrectionInterviewMap : ClassMap<CLCurrentCorrectionInterview>
    {
        public CLCurrentCorrectionInterviewMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.FromWhen).Nullable().Length(1000);
            Map(x => x.VisusBothEyes).Nullable();

            HasMany(x => x.CLCurrentCorrections).Inverse().Cascade.All();
            HasMany(x => x.Cards).Inverse().Cascade.All();
        }
    }
}
