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
//  TODO: using Patient_Cards_Model.Entities;
using Patient_Cards_Model.Database;
using Patient_Cards_Model.DTO;
using Patient_Cards_Model.Interfaces;
//  TODO: using Patient_Cards_Model.Searching;
using Pro = NHibernate.Criterion.Projections;
using Res = NHibernate.Criterion.Restrictions;
using SqlType = NHibernate.NHibernateUtil;

namespace Patient_Cards_Model.Services
{
    public class PreferencesService : IPreferencesService
    {
        public UserPreferencesDTO Preferences { get; private set; }

        public void LoadPreferences()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void SavePreferences(UserPreferencesDTO preferences)
        {
            throw new NotImplementedException();
        }
    }
}
