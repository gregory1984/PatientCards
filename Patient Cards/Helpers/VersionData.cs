using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Cards_Model.Helpers;

namespace Patient_Cards.Helpers
{
    public class VersionData
    {
        private string versionNumber;
        public string VersionNumber
        {
            get => versionNumber;
        }

        private string compilationMarker;
        public string CompilationMarker
        {
            get => compilationMarker;
        }

        private IList<string> technologies;
        public string Technologies
        {
            get => string.Join(", ", technologies);
        }

        private IList<string> authorsData;
        public string AuthorsData
        {
            get => string.Join("\n", authorsData);
        }

        public VersionData()
        {
            versionNumber = Constants.VersionNumber;
            compilationMarker = DateTime.Now.ToString();

            technologies = new List<string>
            {
                "C#", "WPF", "Prism", "SQLite", "NHibernate"
            };

            authorsData = new List<string>
            {
                "Grzegorz Matławski", "Dolnośląskie/Wrocław", "grzegorz.matlawski@gmail.com"
            };
        }
    }
}
