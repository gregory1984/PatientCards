using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Transform;
using NHibernate.Criterion;
using NHibernate.Criterion.Lambda;
using NHibernate.Linq;
using Patient_Cards_Model.Entities;
using Patient_Cards_Model.Entities.GL;
using Patient_Cards_Model.Entities.CL;
using Patient_Cards_Model.Database;
using Patient_Cards_Model.Interfaces;
using Patient_Cards_Model.DTO;
using Pro = NHibernate.Criterion.Projections;
using Res = NHibernate.Criterion.Restrictions;
using SqlType = NHibernate.NHibernateUtil;

namespace Patient_Cards_Model.Services
{
    public class RatesService : IRatesService
    {
        public IList<CLFrontEyeSectionRateDTO> GetCLFrontEyeSectionRates(int? cardId = null)
        {
            using (var session = Hibernate.SessionFactory.OpenSession())
            {
                Card c = null;
                CLFrontEyeSectionRate r = null;
                CLFrontEyeSectionRateIssue i = null;

                var query = session.QueryOver(() => i)
                    .Left.JoinAlias(() => i.CLFrontEyeSectionRates, () => r)
                    .Left.JoinAlias(() => r.Card, () => c);

                if (cardId.HasValue) query.Where(Res.Eq(Pro.Property("c.Id"), cardId.Value));
                else query.Where(Res.IsNull("c.Id"));

                query.SelectList(l => l
                    .Select(() => r.Id)
                    .Select(() => r.CurrentVisitRate)
                    .Select(() => r.ControlVisitRate)
                    .Select(() => c.Id)
                    .Select(() => i.Id)
                    .Select(() => i.Name))
                .OrderBy(() => i.Id).Asc
                .TransformUsing(Transformers.AliasToBeanConstructor(typeof(CLFrontEyeSectionRateDTO).GetConstructors()[1]));

                return query.List<CLFrontEyeSectionRateDTO>();
            }
        }

        public IList<CLMatchedCorrectionRateDTO> GetCLMatchedCorrectionRates(int? cardId = null)
        {
            using (var session = Hibernate.SessionFactory.OpenSession())
            {
                Card c = null;
                CLMatchedCorrectionRate r = null;
                CLMatchedCorrectionRateIssue i = null;

                var query = session.QueryOver(() => i)
                    .Left.JoinAlias(() => i.CLMatchedCorrectionRates, () => r)
                    .Left.JoinAlias(() => r.Card, () => c);

                if (cardId.HasValue) query.Where(Res.Eq(Pro.Property("c.Id"), cardId.Value));
                else query.Where(Res.IsNull("c.Id"));

                query.SelectList(l => l
                    .Select(() => r.Id)
                    .Select(() => r.CurrentVisitRate)
                    .Select(() => r.ControlVisitRate)
                    .Select(() => c.Id)
                    .Select(() => i.Id)
                    .Select(() => i.Name))
                .OrderBy(() => i.Id).Asc
                .TransformUsing(Transformers.AliasToBeanConstructor(typeof(CLMatchedCorrectionRateDTO).GetConstructors()[1]));

                return query.List<CLMatchedCorrectionRateDTO>();
            }
        }
    }
}
