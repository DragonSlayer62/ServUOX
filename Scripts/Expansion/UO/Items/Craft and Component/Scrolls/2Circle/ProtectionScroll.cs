using System;

namespace Server.Items
{
    public class ProtectionScroll : SpellScroll
    {
        [Constructible]
        public ProtectionScroll()
            : this(1)
        {
        }

        [Constructible]
        public ProtectionScroll(int amount)
            : base(14, 0x1F3B, amount)
        {
        }

        public ProtectionScroll(Serial serial)
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