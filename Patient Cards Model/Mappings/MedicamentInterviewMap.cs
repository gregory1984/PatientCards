using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities;

namespace Patient_Cards_Model.Mappings
{
    public class MedicamentInterviewMap : ClassMap<MedicamentInterview>
    {
        public MedicamentInterviewMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.Optionals).Nullable().Length(1000);

            HasManyToMany(x => x.Medicaments).Cascade.SaveUpdate();
            HasMany(x => x.Cards).Inverse().Cascade.SaveUpdate();
        }
    }
}
