using System.Reflection;

namespace ClassicBot.Statics
{
    internal static class Strings
    {
        public const string Process = "WowB";

        public static string Name = Assembly.GetExecutingAssembly().GetName().Name;
        public static string Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public const string Injector = "ClassicBot.Injector.dll";
        public const string Loader = "ClassicBot.Loader.dll";

        public const string Bases = "Bases";
        public const string Plugins = "Plugins";
    }
}
