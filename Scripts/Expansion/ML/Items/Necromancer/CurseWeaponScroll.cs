using System;

namespace Server.Items
{
    public class CurseWeaponScroll : SpellScroll
    {
        [Constructible]
        public CurseWeaponScroll()
            : this(1)
        {
        }

        [Constructible]
        public CurseWeaponScroll(int amount)
            : base(103, 0x2263, amount)
        {
        }

        public CurseWeaponScroll(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}