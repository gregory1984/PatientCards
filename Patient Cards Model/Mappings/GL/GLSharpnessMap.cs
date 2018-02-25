using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities.GL;

namespace Patient_Cards_Model.Mappings.GL
{
    public class GLSharpnessMap : ClassMap<GLSharpness>
    {
        public GLSharpnessMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.CurrentCorrection).Nullable();
            Map(x => x.SC).Nullable();
            Map(x => x.CC).Nullable();

            References(x => x.Card);
            References(x => x.Eye);
        }
    }
}
