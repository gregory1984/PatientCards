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
    public class SharpnessService : ISharpnessService
    {
        public IList<GLSharpnessDTO> GetGLSharpnesses(int? cardId = null)
        {
            using (var session = Hibernate.SessionFactory.OpenSession())
            {
                Eye e = null;
                Card c = null;
                GLSharpness g = null;

                var query = session.QueryOver(() => e)
                    .Left.JoinAlias(() => e.GLSharpnesses, () => g)
                    .Left.JoinAlias(() => g.Card, () => c);

                if (cardId.HasValue) query.Where(Res.Eq(Pro.Property("c.Id"), cardId.Value));
                else query.Where(Res.IsNull("c.Id"));

                query.SelectList(l => l
                    .Select(() => g.Id)
                    .Select(() => e.Id)
                    .Select(() => e.Name)
                    .Select(() => c.Id)
                    .Select(() => g.CurrentCorrection)
                    .Select(() => g.SC)
                    .Select(() => g.CC))
                .OrderBy(() => e.Name).Asc
                .TransformUsing(Transformers.AliasToBeanConstructor(typeof(GLSharpnessDTO).GetConstructors()[1]));

                return query.List<GLSharpnessDTO>();
            }
        }

        public IList<CLSharpnessDTO> GetCLSharpnesses(int? cardId = null)
        {
            using (var session = Hibernate.SessionFactory.OpenSession())
            {
                Eye e = null;
                Card c = null;
                CLSharpness cl = null;

                var query = session.QueryOver(() => e)
                    .Left.JoinAlias(() => e.GLSharpnesses, () => cl)
                    .Left.JoinAlias(() => cl.Card, () => c);

                if (cardId.HasValue) query.Where(Res.Eq(Pro.Property("c.Id"), cardId.Value));
                else query.Where(Res.IsNull("c.Id"));

                query.SelectList(l => l
                    .Select(() => cl.Id)
                    .Select(() => e.Id)
                    .Select(() => e.Name)
                    .Select(() => c.Id)
                    .Select(() => cl.CurrentCorrection)
                    .Select(() => cl.CC))
                .OrderBy(() => e.Name).Asc
                .TransformUsing(Transformers.AliasToBeanConstructor(typeof(CLSharpnessDTO).GetConstructors()[1]));

                return query.List<CLSharpnessDTO>();
            }
        }
    }
}
