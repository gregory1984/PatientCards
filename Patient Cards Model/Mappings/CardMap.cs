using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities;

namespace Patient_Cards_Model.Mappings
{
    public class CardMap : ClassMap<Card>
    {
        public CardMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.Comments).Nullable().Length(1000);

            References(x => x.PersonalInterview);
            References(x => x.ComplaintInterview);
            References(x => x.IllnessInterview);
            References(x => x.OtherInterview);
            References(x => x.MedicamentInterview);

            References(x => x.GLCurrentCorrectionInterview);
            References(x => x.CLCurrentCorrectionInterview);
            References(x => x.GLSharpnessInterview);
            References(x => x.GLMatchedCorrectionInterview);
            References(x => x.CLFrontEyeSectionRateInterview);
            References(x => x.CLSharpnessInterview);
            References(x => x.CLMatchedCorrectionRateInterview);
            References(x => x.CLMatchedCorrectionInterview);
        }
    }
}
