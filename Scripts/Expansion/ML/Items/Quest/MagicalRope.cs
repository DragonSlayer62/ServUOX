using System;

namespace Server.Items
{
    public class MagicalRope : PeerlessKey
    {
        [Constructible]
        public MagicalRope()
            : base(0x20D)
        {
            LootType = LootType.Blessed;
            Weight = 5.0;
        }

        public MagicalRope(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber => 1074338;// Magical Rope	
        public override int Lifespan => 600;
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