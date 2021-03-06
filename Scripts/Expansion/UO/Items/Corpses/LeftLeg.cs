namespace Server.Items
{
    public class LeftLeg : Item
    {
        [Constructible]
        public LeftLeg()
            : base(0x1DA3)
        {
        }

        public LeftLeg(Serial serial)
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
