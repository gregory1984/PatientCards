using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities;

namespace Patient_Cards_Model.Mappings
{
    public class InitializationMap : ClassMap<Initialization>
    {
        public InitializationMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.Version).Unique().Not.Nullable().Length(1000);
            Map(x => x.Date).Not.Nullable();
        }
    }
}
