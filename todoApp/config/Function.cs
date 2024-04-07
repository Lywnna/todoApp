using System.Reflection;

namespace todoApp.config
{
    internal static class Function
    {
        public static string GetExeLocation()
        {
            return System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        }
        public static string GetExeName()
        {
            return Assembly.GetEntryAssembly().Location;
        }
    }
}
