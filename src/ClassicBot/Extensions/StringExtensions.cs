using System.IO;
using System.Linq;

namespace ClassicBot.Extensions
{
    internal static class StringExtensions
    {
        public static void CheckFile(this string value, byte[] bytes)
        {
            if (!value.FileEqualTo(bytes))
                value.CreateFile(bytes);
        }

        public static void CheckDirectory(this string value)
        {
            if (!Directory.Exists(value))
                Directory.CreateDirectory(value);
        }

        static void CreateFile(this string value, byte[] bytes)
        {
            if (File.Exists(value))
            {
                if (File.ReadAllBytes(value).SequenceEqual(bytes)) return;
                File.WriteAllBytes(value, bytes);
            }
            else
                File.WriteAllBytes(value, bytes);
        }

        static bool FileEqualTo(this string value, byte[] bytes)
        {
            if (File.Exists(value))
                return File.ReadAllBytes(value).SequenceEqual(bytes);
            return false;
        }
    }
}
