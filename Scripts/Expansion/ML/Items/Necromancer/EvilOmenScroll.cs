using System;

namespace Server.Items
{
    public class EvilOmenScroll : SpellScroll
    {
        [Constructible]
        public EvilOmenScroll()
            : this(1)
        {
        }

        [Constructible]
        public EvilOmenScroll(int amount)
            : base(104, 0x2264, amount)
        {
        }

        public EvilOmenScroll(Serial serial)
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