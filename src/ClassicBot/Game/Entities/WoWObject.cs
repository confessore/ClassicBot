using ClassicBot.Enums;
using ClassicBot.Game.Models;
using System;

namespace ClassicBot.Game.Entities
{
    public class WoWObject
    {
        public WoWObject(ulong guid, IntPtr pointer, WoWObjectType type)
        {
            Guid = guid;
            Pointer = pointer;
            Type = type;
        }

        public ulong Guid { get; }
        public IntPtr Pointer { get; }
        public WoWObjectType Type { get; }
        public string Name { get; internal set; }
        public Location Position { get; internal set; }
    }
}
