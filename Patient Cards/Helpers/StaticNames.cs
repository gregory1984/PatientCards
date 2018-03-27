using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards.Helpers
{
    public static class StaticNames
    {
        public static string VersionData { get; } = nameof(VersionData);
        public static string ActiveTabBackground { get; } = "#000000";
        public static string InactiveTabBackground { get; } = "#83919f";
    }
}
