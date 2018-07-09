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
using Patient_Cards_Model.Interfaces;
//  TODO: using Patient_Cards_Model.Searching;
using Pro = NHibernate.Criterion.Projections;
using Res = NHibernate.Criterion.Restrictions;
using SqlType = NHibernate.NHibernateUtil;

namespace Patient_Cards_Model.Services
{
    public class DatabaseService : IDatabaseService
    {
        public void Initialize()
        {
            if (IsDatabaseEmpty())
            {
                using (var session = Hibernate.SessionFactory.OpenSession())
                {
                    InsertInitialData(session);
                    InsertIllnesses(session);
                    InsertOthers(session);
                    InsertMedicaments(session);
                    InsertComplaints(session);
                    InsertGLFinallyMatchedCorrectionTypes(session);
                    InsertGLMatchedCorrectionTypes(session);
                    InsertCLProfessionConditions(session);
                    InsertCLMatchedCorrectionTypes(session);
                    InsertCLWearingTypes(session);
                    InsertEyes(session);
                    InsertBases(session);
                    InsertDistances(session);
                    InsertCLFrontEyeSectionRateIssues(session);
                    InsertCLMatchedCorrectionRateIssues(session);
                }
            }
        }

        private bool IsDatabaseEmpty()
        {
            using (var session = Hibernate.SessionFactory.OpenSession())
            {
                return session.QueryOver<Initialization>().RowCount() == 0;
            }
        }

        private bool IsUpdated(ISession session)
        {
            return session.QueryOver<Initialization>()
                .Where(i => i.Version == Constants.VersionNumber)
                .RowCount() == 1;
        }

        private void InsertInitialData(ISession session)
        {
            var init = new Initialization
            {
                Id = 1,
                Version = Constants.VersionNumber,
                Date = DateTime.Now
            };

            session.Save(init);
            session.Flush();
        }

        private void InsertIllnesses(ISession session)
        {
            var illnesses = new List<Illness>
            {
                new Illness{ Id = 1, Name = "Jaskra" },
                new Illness{ Id = 2, Name = "Zaćma" },
                new Illness{ Id = 3, Name = "AMD" },
                new Illness{ Id = 4, Name = "Cukrzyca" },
                new Illness{ Id = 5, Name = "Choroby tarczycy" },
                new Illness{ Id = 6, Name = "Nadciśnienie" },
            };

            foreach (Illness i in illnesses)
            {
                session.Save(i);
            }
            session.Flush();
        }

        private void InsertOthers(ISession session)
        {
            var others = new List<Other>
            {
                new Other{ Id = 1, Name = "Urazy" },
                new Other{ Id = 2, Name = "Infekcje" },
                new Other{ Id = 3, Name = "Alergie" }
            };

            foreach (Other o in others)
            {
                session.Save(o);
            }
            session.Flush();
        }

        private void InsertMedicaments(ISession session)
        {
            var medicaments = new List<Medicament>
            {
                new Medicament{ Id = 1, Name = "Psychotropowe" },
                new Medicament{ Id = 2, Name = "W leczeniu nadciśnienia" },
                new Medicament{ Id = 3, Name = "W leczeniu chorób tarczycy" },
                new Medicament{ Id = 4, Name = "Terapia hormonalna" },
                new Medicament{ Id = 5, Name = "Antykoncepcja" }
            };

            foreach (Medicament m in medicaments)
            {
                session.Save(m);
            }
            session.Flush();
        }

        private void InsertComplaints(ISession session)
        {
            var complaints = new List<Complaint>
            {
                new Complaint{ Id = 1, Name = "Łzawienie" },
                new Complaint{ Id = 2, Name = "Pieczenie" },
                new Complaint{ Id = 3, Name = "Bóle oczu" },
                new Complaint{ Id = 4, Name = "Bóle głowy" }
            };

            foreach (Complaint c in complaints)
            {
                session.Save(c);
            }
            session.Flush();
        }

        private void InsertGLFinallyMatchedCorrectionTypes(ISession session)
        {
            var types = new List<GLFinallyMatchedCorrectionType>
            {
                new GLFinallyMatchedCorrectionType{ Id = 1, Name = "Dal" },
                new GLFinallyMatchedCorrectionType{ Id = 2, Name = "Bliż" },
                new GLFinallyMatchedCorrectionType{ Id = 3, Name = "Progres" }
            };

            foreach (GLFinallyMatchedCorrectionType t in types)
            {
                session.Save(t);
            }
            session.Flush();
        }

        private void InsertGLMatchedCorrectionTypes(ISession session)
        {
            var types = new List<GLMatchedCorrectionType>
            {
                new GLMatchedCorrectionType{ Id = 1, Name = "Dobrana korekcja na foropterze" },
                new GLMatchedCorrectionType{ Id = 2, Name = "Ostatneczna dobrana korekcja okularowa" },
            };

            foreach (GLMatchedCorrectionType t in types)
            {
                session.Save(t);
            }
            session.Flush();
        }

        private void InsertCLProfessionConditions(ISession session)
        {
            var conditions = new List<CLProfessionCondition>
            {
                new CLProfessionCondition{ Id = 1, Name = "W klimatyzowanym pomieszczeniu" },
                new CLProfessionCondition{ Id = 2, Name = "W zapylonym środowisku" },
            };

            foreach (CLProfessionCondition c in conditions)
            {
                session.Save(c);
            }
            session.Flush();
        }

        private void InsertCLMatchedCorrectionTypes(ISession session)
        {
            var types = new List<CLMatchedCorrectionType>
            {
                new CLMatchedCorrectionType{ Id = 1, Name = "Próbne" },
                new CLMatchedCorrectionType{ Id = 2, Name = "Handlowe" }
            };

            foreach (CLMatchedCorrectionType t in types)
            {
                session.Save(t);
            }
            session.Flush();
        }

        private void InsertCLWearingTypes(ISession session)
        {
            var types = new List<CLWearingType>
            {
                new CLWearingType{ Id = 1, Name = "Jednodniowy" },
                new CLWearingType{ Id = 2, Name = "Dwutygodniowy" },
                new CLWearingType{ Id = 3, Name = "Miesięczny" },
                new CLWearingType{ Id = 4, Name = "Roczny" },
            };

            foreach (CLWearingType t in types)
            {
                session.Save(t);
            }
            session.Flush();
        }

        private void InsertEyes(ISession session)
        {
            var eyes = new List<Eye>
            {
                new Eye{ Id = 1, Name = "OL" },
                new Eye{ Id = 2, Name = "OP" },
                new Eye{ Id = 3, Name = "OU" }
            };

            foreach (Eye e in eyes)
            {
                session.Save(e);
            }
            session.Flush();
        }

        private void InsertBases(ISession session)
        {
            var bases = new List<Base>
            {
                new Base{ Id = 1, Name = "BS" },
                new Base{ Id = 2, Name = "BN" },
                new Base{ Id = 3, Name = "BG" },
                new Base{ Id = 4, Name = "BD" }
            };

            foreach (Base b in bases)
            {
                session.Save(b);
            }
            session.Flush();
        }

        private void InsertDistances(ISession session)
        {
            var distances = new List<Distance>
            {
                new Distance{ Id = 1, Name = "Bliż" },
                new Distance{ Id = 2, Name = "Pośrednie" },
                new Distance{ Id = 3, Name = "Dal" }
            };

            foreach (Distance d in distances)
            {
                session.Save(d);
            }
            session.Flush();
        }

        private void InsertCLFrontEyeSectionRateIssues(ISession session)
        {
            var issues = new List<CLFrontEyeSectionRateIssue>
            {
                new CLFrontEyeSectionRateIssue { Id = 1, Name = "Powieki/rzęsy - Przekrwienie powiek" },
                new CLFrontEyeSectionRateIssue { Id = 2, Name = "Powieki/rzęsy - Niedomykalność/odwinięcie/podwinięcie" },
                new CLFrontEyeSectionRateIssue { Id = 3, Name = "Powieki/rzęsy - Jęczmienie/łuski na rzęsach" },
                new CLFrontEyeSectionRateIssue { Id = 4, Name = "Brzeg powieki górnej i dolnej - Stan gruczołów Melborna" },
                new CLFrontEyeSectionRateIssue { Id = 5, Name = "Brzeg powieki górnej i dolnej - Przekrwienie/zapalenie brzegów powiek" },
                new CLFrontEyeSectionRateIssue { Id = 6, Name = "Film łzowy - Menisk łzowy" },
                new CLFrontEyeSectionRateIssue { Id = 7, Name = "Film łzowy - BUT - czas przerwania filmu łzowego" },
                new CLFrontEyeSectionRateIssue { Id = 8, Name = "Film łzowy - NaFl - ocena filmu łzowego" },
                new CLFrontEyeSectionRateIssue { Id = 9, Name = "Spojówka gałkowa - Przekrwienie/tłuszczyk/skrzydlik" },
                new CLFrontEyeSectionRateIssue { Id = 10, Name = "Rąbek rogówki - Przekrwienie rąbka/neowaskularyzacja rąbka" },
                new CLFrontEyeSectionRateIssue { Id = 11, Name = "Rogówka - Obrzęk/nacieki" },
                new CLFrontEyeSectionRateIssue { Id = 12, Name = "Rogówka - Przezierność" },
                new CLFrontEyeSectionRateIssue { Id = 13, Name = "Tęczówka - Ocena zmian barwnikowych" },
                new CLFrontEyeSectionRateIssue { Id = 14, Name = "Źrenica - Reakcja źrenic na światło" },
                new CLFrontEyeSectionRateIssue { Id = 15, Name = "Źrenica - Nieregularny kształt/decentracja" },
                new CLFrontEyeSectionRateIssue { Id = 16, Name = "Soczewka - Przezierność" },
                new CLFrontEyeSectionRateIssue { Id = 17, Name = "Soczewka - Zmiany patologiczne" },
                new CLFrontEyeSectionRateIssue { Id = 18, Name = "Spojówka - Przekrwienie/grudki/brodawki" }
            };

            foreach (CLFrontEyeSectionRateIssue i in issues)
            {
                session.Save(i);
            }
            session.Flush();
        }

        private void InsertCLMatchedCorrectionRateIssues(ISession session)
        {
            var issues = new List<CLMatchedCorrectionRateIssue>
            {
                new CLMatchedCorrectionRateIssue { Id = 1, Name = "Centracja" },
                new CLMatchedCorrectionRateIssue { Id = 2, Name = "Ruchomość" },
                new CLMatchedCorrectionRateIssue { Id = 3, Name = "Pokrycie rogówki" },
                new CLMatchedCorrectionRateIssue { Id = 4, Name = "Rotacja" },
                new CLMatchedCorrectionRateIssue { Id = 5, Name = "Komfort" }
            };

            foreach (CLMatchedCorrectionRateIssue i in issues)
            {
                session.Save(i);
            }
            session.Flush();
        }
    }
}
