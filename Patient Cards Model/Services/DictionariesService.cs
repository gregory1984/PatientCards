using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Transform;
using NHibernate.Criterion;
using NHibernate.Criterion.Lambda;
using NHibernate.Linq;
using Patient_Cards_Model.Helpers;
using Patient_Cards_Model.Entities;
using Patient_Cards_Model.Entities.GL;
using Patient_Cards_Model.Entities.CL;
using Patient_Cards_Model.Database;
using Patient_Cards_Model.DTO;
using Patient_Cards_Model.DTO.CL;
using Patient_Cards_Model.DTO.GL;
using Patient_Cards_Model.Interfaces;
using Pro = NHibernate.Criterion.Projections;
using Res = NHibernate.Criterion.Restrictions;
using SqlType = NHibernate.NHibernateUtil;
using System.Reflection;

namespace Patient_Cards_Model.Services
{
    public class DictionariesService : IDictionariesService
    {
        private IDictionary<int, GLFinallyMatchedCorrectionTypeDTO> gLFinallyMatchedCorrectionTypes;
        public IDictionary<int, GLFinallyMatchedCorrectionTypeDTO> GLFinallyMatchedCorrectionTypes
        {
            get
            {
                if (gLFinallyMatchedCorrectionTypes == null)
                {
                    using (var session = Hibernate.SessionFactory.OpenSession())
                    {
                        var types = session.QueryOver<GLFinallyMatchedCorrectionType>()
                           .SelectList(l => l
                               .Select(t => t.Id)
                               .Select(t => t.Name))
                           .TransformUsing(Transformers.AliasToBeanConstructor(typeof(GLFinallyMatchedCorrectionTypeDTO).GetConstructors()[1]))
                           .List<GLFinallyMatchedCorrectionTypeDTO>();

                        gLFinallyMatchedCorrectionTypes = new Dictionary<int, GLFinallyMatchedCorrectionTypeDTO>();
                        foreach (GLFinallyMatchedCorrectionTypeDTO t in types)
                        {
                            gLFinallyMatchedCorrectionTypes.Add(t.Id.Value, t);
                        }
                    }
                }
                return gLFinallyMatchedCorrectionTypes;
            }
        }

        private IDictionary<int, CLWearingTypeDTO> cLWearingTypes;
        public IDictionary<int, CLWearingTypeDTO> CLWearingTypes
        {
            get
            {
                if (cLWearingTypes == null)
                {
                    using (var session = Hibernate.SessionFactory.OpenSession())
                    {
                        var types = session.QueryOver<CLWearingType>()
                           .SelectList(l => l
                               .Select(t => t.Id)
                               .Select(t => t.Name))
                           .TransformUsing(Transformers.AliasToBeanConstructor(typeof(CLWearingTypeDTO).GetConstructors()[1]))
                           .List<CLWearingTypeDTO>();

                        cLWearingTypes = new Dictionary<int, CLWearingTypeDTO>();
                        foreach (CLWearingTypeDTO t in types)
                        {
                            cLWearingTypes.Add(t.Id.Value, t);
                        }
                    }
                }
                return cLWearingTypes;
            }
        }

        private IDictionary<int, BaseDTO> bases;
        public IDictionary<int, BaseDTO> Bases
        {
            get
            {
                if (bases == null)
                {
                    using (var session = Hibernate.SessionFactory.OpenSession())
                    {
                        var bs = session.QueryOver<Base>()
                           .SelectList(l => l
                               .Select(t => t.Id)
                               .Select(t => t.Name))
                           .TransformUsing(Transformers.AliasToBeanConstructor(typeof(BaseDTO).GetConstructors()[1]))
                           .List<BaseDTO>();

                        bases = new Dictionary<int, BaseDTO>();
                        foreach (BaseDTO b in bs)
                        {
                            bases.Add(b.Id.Value, b);
                        }
                    }
                }
                return bases;
            }
        }

        private IDictionary<int, ComplaintDTO> complaints;
        public IDictionary<int, ComplaintDTO> Complaints
        {
            get
            {
                if (complaints == null)
                {
                    using (var session = Hibernate.SessionFactory.OpenSession())
                    {
                        var cpl = session.QueryOver<Complaint>()
                           .SelectList(l => l
                               .Select(t => t.Id)
                               .Select(t => t.Name))
                           .TransformUsing(Transformers.AliasToBeanConstructor(typeof(ComplaintDTO).GetConstructors()[1]))
                           .List<ComplaintDTO>();

                        complaints = new Dictionary<int, ComplaintDTO>();
                        foreach (ComplaintDTO c in cpl)
                        {
                            complaints.Add(c.Id.Value, c);
                        }
                    }
                }
                return complaints;
            }
        }

        private IDictionary<int, MedicamentDTO> medicaments;
        public IDictionary<int, MedicamentDTO> Medicaments
        {
            get
            {
                if (medicaments == null)
                {
                    using (var session = Hibernate.SessionFactory.OpenSession())
                    {
                        var meds = session.QueryOver<Medicament>()
                           .SelectList(l => l
                               .Select(t => t.Id)
                               .Select(t => t.Name))
                           .TransformUsing(Transformers.AliasToBeanConstructor(typeof(MedicamentDTO).GetConstructors()[1]))
                           .List<MedicamentDTO>();

                        medicaments = new Dictionary<int, MedicamentDTO>();
                        foreach (MedicamentDTO m in meds)
                        {
                            medicaments.Add(m.Id.Value, m);
                        }
                    }
                }
                return medicaments;
            }
        }

        private IDictionary<int, OtherDTO> others;
        public IDictionary<int, OtherDTO> Others
        {
            get
            {
                if (others == null)
                {
                    using (var session = Hibernate.SessionFactory.OpenSession())
                    {
                        var oth = session.QueryOver<Other>()
                           .SelectList(l => l
                               .Select(t => t.Id)
                               .Select(t => t.Name))
                           .TransformUsing(Transformers.AliasToBeanConstructor(typeof(OtherDTO).GetConstructors()[1]))
                           .List<OtherDTO>();

                        others = new Dictionary<int, OtherDTO>();
                        foreach (OtherDTO o in oth)
                        {
                            others.Add(o.Id.Value, o);
                        }
                    }
                }
                return others;
            }
        }

        private IDictionary<int, IllnessDTO> illnesses;
        public IDictionary<int, IllnessDTO> Illnesses
        {
            get
            {
                if (illnesses == null)
                {
                    using (var session = Hibernate.SessionFactory.OpenSession())
                    {
                        var ill = session.QueryOver<Illness>()
                           .SelectList(l => l
                               .Select(t => t.Id)
                               .Select(t => t.Name))
                           .TransformUsing(Transformers.AliasToBeanConstructor(typeof(IllnessDTO).GetConstructors()[1]))
                           .List<IllnessDTO>();

                        illnesses = new Dictionary<int, IllnessDTO>();
                        foreach (IllnessDTO i in ill)
                        {
                            illnesses.Add(i.Id.Value, i);
                        }
                    }
                }
                return illnesses;
            }
        }

        private IDictionary<int, DistanceDTO> distantes;
        public IDictionary<int, DistanceDTO> Distances
        {
            get
            {
                if (distantes == null)
                {
                    using (var session = Hibernate.SessionFactory.OpenSession())
                    {
                        var dist = session.QueryOver<Distance>()
                           .SelectList(l => l
                               .Select(t => t.Id)
                               .Select(t => t.Name))
                           .TransformUsing(Transformers.AliasToBeanConstructor(typeof(DistanceDTO).GetConstructors()[1]))
                           .List<DistanceDTO>();

                        distantes = new Dictionary<int, DistanceDTO>();
                        foreach (DistanceDTO d in dist)
                        {
                            distantes.Add(d.Id.Value, d);
                        }
                    }
                }
                return distantes;
            }
        }

        private IDictionary<int, CLProfessionConditionDTO> cLProfessionConditions;
        public IDictionary<int, CLProfessionConditionDTO> CLProfessionConditions
        {
            get
            {
                if (cLProfessionConditions == null)
                {
                    using (var session = Hibernate.SessionFactory.OpenSession())
                    {
                        var profs = session.QueryOver<CLProfessionCondition>()
                           .SelectList(l => l
                               .Select(t => t.Id)
                               .Select(t => t.Name))
                           .TransformUsing(Transformers.AliasToBeanConstructor(typeof(CLProfessionConditionDTO).GetConstructors()[1]))
                           .List<CLProfessionConditionDTO>();

                        cLProfessionConditions = new Dictionary<int, CLProfessionConditionDTO>();
                        foreach (CLProfessionConditionDTO c in profs)
                        {
                            cLProfessionConditions.Add(c.Id.Value, c);
                        }
                    }
                }
                return cLProfessionConditions;
            }
        }
    }
}
