using System;

namespace Server.Items
{
    public class PoisonFieldScroll : SpellScroll
    {
        [Constructible]
        public PoisonFieldScroll()
            : this(1)
        {
        }

        [Constructible]
        public PoisonFieldScroll(int amount)
            : base(38, 0x1F53, amount)
        {
        }

        public PoisonFieldScroll(Serial serial)
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
