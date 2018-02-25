using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities;

namespace Patient_Cards_Model.Mappings
{
    public class EyeMap : ClassMap<Eye>
    {
        public EyeMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.Name).Not.Nullable().Length(1000);

            HasMany(x => x.CLSharpnesses).Inverse().Cascade.SaveUpdate();
            HasMany(x => x.GLSharpnesses).Inverse().Cascade.SaveUpdate();
            HasMany(x => x.GLMachedCorrections).Inverse().Cascade.SaveUpdate();
            HasMany(x => x.CLMachedCorrections).Inverse().Cascade.SaveUpdate();
            HasMany(x => x.CLCurrentCorrections).Inverse().Cascade.SaveUpdate();
            HasMany(x => x.GLCurrentCorrections).Inverse().Cascade.SaveUpdate();
        }
    }
}
