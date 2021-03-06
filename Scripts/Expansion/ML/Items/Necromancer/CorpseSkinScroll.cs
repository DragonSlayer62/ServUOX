using System;

namespace Server.Items
{
    public class CorpseSkinScroll : SpellScroll
    {
        [Constructible]
        public CorpseSkinScroll()
            : this(1)
        {
        }

        [Constructible]
        public CorpseSkinScroll(int amount)
            : base(102, 0x2262, amount)
        {
        }

        public CorpseSkinScroll(Serial serial)
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