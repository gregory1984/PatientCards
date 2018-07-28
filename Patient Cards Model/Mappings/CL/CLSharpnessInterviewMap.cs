using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities.CL;

namespace Patient_Cards_Model.Mappings.CL
{
    public class CLSharpnessInterviewMap : ClassMap<CLSharpnessInterview>
    {
        public CLSharpnessInterviewMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();

            HasMany(x => x.CLSharpnesses).Inverse().Cascade.All();
            HasMany(x => x.Cards).Inverse().Cascade.All();
        }
    }
}
