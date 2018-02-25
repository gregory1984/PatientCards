using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities.CL;

namespace Patient_Cards_Model.Mappings.CL
{
    public class CLWearingTypeMap : ClassMap<CLWearingType>
    {
        public CLWearingTypeMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.Name).Not.Nullable().Length(1000);

            HasMany(x => x.CardsCurrent).Inverse().Cascade.SaveUpdate();
            HasMany(x => x.CardsTest).Inverse().Cascade.SaveUpdate();
            HasMany(x => x.CardsTrade).Inverse().Cascade.SaveUpdate();
        }
    }
}
