using System;

namespace Server.Items
{
    public class DispelFieldScroll : SpellScroll
    {
        [Constructible]
        public DispelFieldScroll()
            : this(1)
        {
        }

        [Constructible]
        public DispelFieldScroll(int amount)
            : base(33, 0x1F4E, amount)
        {
        }

        public DispelFieldScroll(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            _ = reader.ReadInt();
        }
    }
}
