using ClassicBot.Enums;
using System;

namespace ClassicBot.Game.Entities
{
    public class WoWUnit : WoWObject
    {
        public WoWUnit(ulong guid, IntPtr pointer, WoWObjectType type)
            : base(guid, pointer, type) { }
    }
}
