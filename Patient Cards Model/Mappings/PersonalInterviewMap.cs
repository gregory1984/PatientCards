using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Patient_Cards_Model.Entities;

namespace Patient_Cards_Model.Mappings
{
    public class PersonalInterviewMap : ClassMap<PersonalInterview>
    {
        public PersonalInterviewMap()
        {
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.CurrentVisitDate).Not.Nullable();
            Map(x => x.PreviousVisitDate).Nullable().Length(1000);
            Map(x => x.ControlVisitDate).Nullable();
            Map(x => x.VisitCause).Nullable().Length(1000);
            Map(x => x.ProfessionOrHobby).Nullable().Length(1000);
            Map(x => x.IsComputerProfession).Not.Nullable();
            Map(x => x.ComputerProfessionOptionals).Nullable().Length(1000);
            Map(x => x.IsCarDriving).Not.Nullable();
            Map(x => x.CarDrivingOptionals).Nullable().Length(1000);
            Map(x => x.CLProfessionConditionOptionals).Nullable().Length(1000);
            Map(x => x.Treatments).Nullable().Length(1000);

            References(x => x.Patient);
            References(x => x.Distance);
            References(x => x.CLProfessionCondition);

            HasMany(x => x.Cards).Inverse().Cascade.All();
        }
    }
}
