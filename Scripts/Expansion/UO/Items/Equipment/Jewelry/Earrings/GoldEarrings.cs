namespace Server.Items
{
    public class GoldEarrings : BaseEarrings
    {
        [Constructible]
        public GoldEarrings()
            : base(0x1087)
        {
        }

        public GoldEarrings(Serial serial)
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
