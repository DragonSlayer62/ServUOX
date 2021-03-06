using System;

namespace Server.Items
{
    public class SummonDaemonScroll : SpellScroll
    {
        [Constructible]
        public SummonDaemonScroll()
            : this(1)
        {
        }

        [Constructible]
        public SummonDaemonScroll(int amount)
            : base(60, 0x1F69, amount)
        {
        }

        public SummonDaemonScroll(Serial serial)
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
