using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using todoApp.config;

namespace todoApp.data
{
    internal static class Lang
    {
        public enum AvaliableLangs
        {
            pt,
            en
        }
        public static void LoadLang(AvaliableLangs language)
        {
            IniFile ini;
            Dictionary<string, string> dic = new Dictionary<string,string>();
            switch (language)
            {
                case AvaliableLangs.pt:
                    ini = new IniFile(Function.GetExeLocation() + @"\config\lang\pt.ini");
                    break;

                case AvaliableLangs.en:
                    ini = new IniFile(Function.GetExeLocation() + @"\config\lang\en.ini");
                    break;
            }

        }
    }
}
