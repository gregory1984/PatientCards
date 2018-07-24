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
            Map(x => x.CurrentVisitDate).Not.Nullable();
            Map(x => x.PreviousVisitDate).Nullable().Length(1000);
            Map(x => x.ControlVisitDate).Nullable();
            Map(x => x.VisitCause).Nullable().Length(1000);
            Map(x => x.ProfessionOrHobby).Nullable().Length(1000);
            Map(x => x.IsComputerProfession).Not.Nullable();
            Map(x => x.ComputerProfessionOptional).Nullable().Length(1000);
            Map(x => x.IsCarDriving).Not.Nullable();
            Map(x => x.CarDrivingOptional).Nullable().Length(1000);
            Map(x => x.Comments).Nullable().Length(1000);
            Map(x => x.CLProfessionConditionOptional).Nullable().Length(1000);
            Map(x => x.Treatments).Nullable().Length(1000);
            Map(x => x.GLCurrentCorrectionFromWhen).Nullable().Length(1000);
            Map(x => x.CLCurrentCorrectionFromWhen).Nullable().Length(1000);
            Map(x => x.GLFinallyMatchedCorrectionTypeOptional).Nullable().Length(1000);
            Map(x => x.CurrentGLType).Nullable().Length(1000);

            References(x => x.Patient);
            References(x => x.Distance);

            References(x => x.ComplaintInterview);
            References(x => x.IllnessInterview);
            References(x => x.OtherInterview);
            References(x => x.MedicamentInterview);

            References(x => x.CLWearingTypeCurrent);
            References(x => x.CLWearingTypeMatchedTest);
            References(x => x.CLWearingTypeMatchedTrade);
            References(x => x.GLFinallyMatchedCorrectionType);

            HasMany(x => x.GLCurrentCorrections).Inverse().Cascade.All();
            HasMany(x => x.CLCurrentCorrections).Inverse().Cascade.All();
            HasMany(x => x.GLSharpnesses).Inverse().Cascade.All();
            HasMany(x => x.CLSharpnesses).Inverse().Cascade.All();
            HasMany(x => x.CLFrontEyeSectionRates).Inverse().Cascade.All();
            HasMany(x => x.CLMatchedCorrectionRates).Inverse().Cascade.All();
            HasMany(x => x.CLMatchedCorrections).Inverse().Cascade.All();
            HasMany(x => x.CLPrimaryDatas).Inverse().Cascade.All();

            HasManyToMany(x => x.CLProfessionConditions).Cascade.All();
        }
    }
}
