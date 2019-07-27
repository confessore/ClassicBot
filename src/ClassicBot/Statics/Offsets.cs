using System;

namespace ClassicBot.Statics
{
    internal static class Offsets
    {
        public static IntPtr BaseAddress = System.Diagnostics.Process.GetCurrentProcess().MainModule.BaseAddress;

        public static class EntityManager
        {
            public static IntPtr Base = BaseAddress + 0xCD3BC0;
            public static int First = 0x0;
            public static int Next = 0x0;
            public static int Guid = 0x0;
            public static int Type = 0x0;
        }

        public static class LocalPlayer
        {
            public static IntPtr Base = BaseAddress + 0x1744E0;
            public static IntPtr Scale = Functions.GetLocalPlayerBase() + 0x1820;
        }
    }
}
