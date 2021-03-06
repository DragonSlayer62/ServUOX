using System;

namespace Server.Items
{
    public class PileofInspectedCopperIngots : Item
    {
        [Constructible]
        public PileofInspectedCopperIngots()
            : base(0x1BEA)
        {
            Hue = 2413;
        }

        public PileofInspectedCopperIngots(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber => 1113023;//Pile of Inspected Copper Ingots
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}