namespace Server.Items
{
    public class ArrowCrab : BaseFish
    {
        [Constructible]
        public ArrowCrab()
            : base(0xA37E)
        {
        }

        public ArrowCrab(Serial serial)
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
