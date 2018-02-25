using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities;

namespace Patient_Cards_Model.Mappings
{
    public class PatientMap : ClassMap<Patient>
    {
        public PatientMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.Name).Not.Nullable().Length(1000);
            Map(x => x.Surname).Not.Nullable().Length(1000);

            HasMany(x => x.Cards).Inverse().Cascade.All();
        }
    }
}
