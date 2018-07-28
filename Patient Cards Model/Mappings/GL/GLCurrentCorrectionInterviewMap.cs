using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities.GL;

namespace Patient_Cards_Model.Mappings.GL
{
    public class GLCurrentCorrectionInterviewMap : ClassMap<GLCurrentCorrectionInterview>
    {
        public GLCurrentCorrectionInterviewMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.CurrentGLType).Nullable().Length(1000);
            Map(x => x.FromWhen).Nullable().Length(1000);

            HasMany(x => x.GLCurrentCorrections).Inverse().Cascade.All();
            HasMany(x => x.Cards).Inverse().Cascade.All();
        }
    }
}
