using ClassicBot.Extensions;
using System.Reflection;

namespace ClassicBot.Statics
{
    internal static class Paths
    {
        public static Assembly Assembly = Assembly.GetExecutingAssembly();

        public static string Binary = Assembly.Location;

        public static string Injector = $"{Assembly.JumpUp(1)}\\{Strings.Injector}";
        public static string Loader = $"{Assembly.JumpUp(1)}\\{Strings.Loader}";

        public static string Bases = $"{Assembly.JumpUp(1)}\\{Strings.Bases}";
        public static string Plugins = $"{Assembly.JumpUp(1)}\\{Strings.Plugins}";
    }
}
