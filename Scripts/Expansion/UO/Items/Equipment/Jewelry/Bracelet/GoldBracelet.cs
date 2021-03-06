namespace Server.Items
{
    public class GoldBracelet : BaseBracelet
    {
        [Constructible]
        public GoldBracelet()
            : base(0x1086)
        {
        }

        public GoldBracelet(Serial serial)
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
