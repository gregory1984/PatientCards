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
    public class CorrectionService : ICorrectionService
    {
        public IList<GLMatchedCorrectionDTO> GetGLMatchedCorrections(GLCorrectionType gLCorrectionType, int? cardId = null)
        {
            using (var session = Hibernate.SessionFactory.OpenSession())
            {
                Eye e = null;
                Base b = null;
                Card c = null;
                GLMatchedCorrection gl = null;

                var query = session.QueryOver(() => e)
                    .Left.JoinAlias(() => e.GLMachedCorrections, () => gl)
                    .Left.JoinAlias(() => gl.Base, () => b)
                    .Left.JoinAlias(() => gl.Card, () => c)
                    .Where(Res.In(Pro.Property("e.Id"), new List<int> { 1, 2 }));

                if (cardId.HasValue) query.Where(Res.Eq(Pro.Property("c.Id"), cardId.Value));
                else query.Where(Res.IsNull("c.Id"));

                query.SelectList(l => l
                    .Select(() => gl.Id)
                    .Select(() => gl.Sphere)
                    .Select(() => gl.Cylinder)
                    .Select(() => gl.Axis)
                    .Select(() => gl.Addition)
                    .Select(() => gl.Prism)
                    .Select(() => b.Id)
                    .Select(() => b.Name)
                    .Select(() => e.Id)
                    .Select(() => e.Name)
                    .Select(() => c.Id)
                    .Select(Pro.Conditional(Res.Eq(Pro.Constant((int)gLCorrectionType), 1), Pro.Constant(1), Pro.Constant(2))))
                .OrderBy(() => e.Name).Asc
                .TransformUsing(Transformers.AliasToBeanConstructor(typeof(GLMatchedCorrectionDTO).GetConstructors()[1]));

                return query.List<GLMatchedCorrectionDTO>();
            }
        }

        public IList<CLMatchedCorrectionDTO> GetCLMatchedCorrections(CLCorrectionType cLCorrectionType, int? cardId = null)
        {
            using (var session = Hibernate.SessionFactory.OpenSession())
            {
                Eye e = null;
                Card c = null;
                CLMatchedCorrection cl = null;

                var query = session.QueryOver(() => e)
                    .Left.JoinAlias(() => e.CLMachedCorrections, () => cl)
                    .Left.JoinAlias(() => cl.Card, () => c)
                    .Where(Res.In(Pro.Property("e.Id"), new List<int> { 1, 2 }));

                if (cardId.HasValue) query.Where(Res.Eq(Pro.Property("c.Id"), cardId.Value));
                else query.Where(Res.IsNull("c.Id"));

                query.SelectList(l => l
                    .Select(() => cl.Id)
                    .Select(() => cl.Sphere)
                    .Select(() => cl.Cylinder)
                    .Select(() => cl.Axis)
                    .Select(() => cl.Addition)
                    .Select(() => cl.BC)
                    .Select(() => cl.DIA)
                    .Select(() => e.Id)
                    .Select(() => e.Name)
                    .Select(() => c.Id)
                    .Select(Pro.Conditional(Res.Eq(Pro.Constant((int)cLCorrectionType), 1), Pro.Constant(1), Pro.Constant(2))))
                .OrderBy(() => e.Name).Asc
                .TransformUsing(Transformers.AliasToBeanConstructor(typeof(CLMatchedCorrectionDTO).GetConstructors()[1]));

                return query.List<CLMatchedCorrectionDTO>();
            }
        }

        public IList<CLPrimaryDataDTO> GetCLPrimaryDatas(int cardId)
        {
            using (var session = Hibernate.SessionFactory.OpenSession())
            {
                throw new NotImplementedException();
            }
        }

        public IList<GLCurrentCorrectionDTO> GetGLCurrentCorrections(int? cardId = null)
        {
            using (var session = Hibernate.SessionFactory.OpenSession())
            {
                Eye e = null;
                Base b = null;
                Card c = null;
                GLCurrentCorrection gl = null;

                var query = session.QueryOver(() => e)
                    .Left.JoinAlias(() => e.GLCurrentCorrections, () => gl)
                    .Left.JoinAlias(() => gl.Base, () => b)
                    .Left.JoinAlias(() => gl.Card, () => c)
                    .Where(Res.In(Pro.Property("e.Id"), new List<int> { 1, 2 }));

                if (cardId.HasValue) query.Where(Res.Eq(Pro.Property("c.Id"), cardId.Value));
                else query.Where(Res.IsNull("c.Id"));

                query.SelectList(l => l
                    .Select(() => gl.Id)
                    .Select(() => gl.Sphere)
                    .Select(() => gl.Cylinder)
                    .Select(() => gl.Axis)
                    .Select(() => gl.Addition)
                    .Select(() => gl.Prism)
                    .Select(() => b.Id)
                    .Select(() => b.Name)
                    .Select(() => e.Id)
                    .Select(() => e.Name)
                    .Select(() => c.Id))
                .OrderBy(() => e.Name).Asc
                .TransformUsing(Transformers.AliasToBeanConstructor(typeof(GLCurrentCorrectionDTO).GetConstructors()[1]));

                return query.List<GLCurrentCorrectionDTO>();
            }
        }

        public IList<CLCurrentCorrectionDTO> GetCLCurrentCorrections(int? cardId = null)
        {
            using (var session = Hibernate.SessionFactory.OpenSession())
            {
                Eye e = null;
                Card c = null;
                CLCurrentCorrection cl = null;

                var query = session.QueryOver(() => e)
                    .Left.JoinAlias(() => e.CLCurrentCorrections, () => cl)
                    .Left.JoinAlias(() => cl.Card, () => c)
                    .Where(Res.In(Pro.Property("e.Id"), new List<int> { 1, 2 }));

                if (cardId.HasValue) query.Where(Res.Eq(Pro.Property("c.Id"), cardId.Value));
                else query.Where(Res.IsNull("c.Id"));

                query.SelectList(l => l
                    .Select(() => cl.Id)
                    .Select(() => cl.Sphere)
                    .Select(() => cl.Cylinder)
                    .Select(() => cl.Axis)
                    .Select(() => cl.Addition)
                    .Select(() => cl.BC)
                    .Select(() => cl.Visus)
                    .Select(() => e.Id)
                    .Select(() => e.Name)
                    .Select(() => c.Id))
                .OrderBy(() => e.Name).Asc
                .TransformUsing(Transformers.AliasToBeanConstructor(typeof(CLCurrentCorrectionDTO).GetConstructors()[1]));

                return query.List<CLCurrentCorrectionDTO>();
            }
        }

        public string GetCurrentCorrectionFromWhen(VisionType visionType, int cardId)
        {
            using (var session = Hibernate.SessionFactory.OpenSession())
            {
                Card c = null;

                return session.QueryOver(() => c)
                    .Where(() => c.Id == cardId)
                    .SelectList(l => l
                        .Select(Pro.Conditional(
                            Res.Eq(Pro.Constant((int)visionType), Pro.Constant(1)), Pro.Property("GLCurrentCorrectionFromWhen"), Pro.Property("CLCurrentCorrectionFromWhen"))))
                    .SingleOrDefault<string>();
            }
        }
    }
}
