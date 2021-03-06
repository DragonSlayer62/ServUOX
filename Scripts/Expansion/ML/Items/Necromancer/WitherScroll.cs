using System;

namespace Server.Items
{
    public class WitherScroll : SpellScroll
    {
        [Constructible]
        public WitherScroll()
            : this(1)
        {
        }

        [Constructible]
        public WitherScroll(int amount)
            : base(114, 0x226E, amount)
        {
        }

        public WitherScroll(Serial serial)
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