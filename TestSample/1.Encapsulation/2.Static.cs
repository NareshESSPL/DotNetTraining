using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Encapsulation
{
    #region static

    public static class ConfigManager
    {
        public static string AppName { get; } = "MyApp";
        public static string GetAppDetails() => $"Welcome to {AppName}";


        public static string Version;
        public static string GetVersion(string minorVersion)
        {
            return Version + "." + minorVersion;
        }
    }

    #endregion
}
