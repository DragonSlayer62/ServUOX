using System;
using Server;

namespace Server.Items
{
    public class GoldPuzzleKey : BaseDecayingItem
    {
        public override int Lifespan => 1800;
        public override int LabelNumber => 1024111;  // gold key

        [Constructible]
        public GoldPuzzleKey() : base(4114)
        {
            Hue = 1174;
        }

        public GoldPuzzleKey(Serial serial) : base(serial)
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
            int version = reader.ReadInt();
        }
    }
}