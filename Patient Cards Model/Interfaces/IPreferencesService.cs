using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Cards_Model.DTO;

namespace Patient_Cards_Model.Interfaces
{
    public interface IPreferencesService
    {
        UserPreferencesDTO Preferences { get; }

        void SavePreferences(UserPreferencesDTO preferences);
        void LoadPreferences();
        void Reset();
    }
}
