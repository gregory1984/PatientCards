using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities.GL;

namespace Patient_Cards_Model.Mappings.GL
{
    public class GLSharpnessInterviewMap : ClassMap<GLSharpnessInterview>
    {
        public GLSharpnessInterviewMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();

            HasMany(x => x.GLSharpnesses).Inverse().Cascade.All();
            HasMany(x => x.Cards).Inverse().Cascade.All();
        }
    }
}
