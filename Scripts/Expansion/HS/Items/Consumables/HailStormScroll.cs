using System;

namespace Server.Items
{
    public class HailStormScroll : SpellScroll
    {
        [Constructible]
        public HailStormScroll()
            : this(1)
        {
        }

        [Constructible]
        public HailStormScroll(int amount)
            : base(690, 0x2DAB, amount)
        {
        }

        public HailStormScroll(Serial serial)
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