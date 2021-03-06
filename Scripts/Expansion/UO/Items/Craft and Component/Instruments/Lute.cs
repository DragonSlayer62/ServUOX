namespace Server.Items
{
    public class Lute : BaseInstrument
    {
        [Constructible]
        public Lute()
            : base(0xEB3, 0x4C, 0x4D)
        {
            Weight = 5.0;
        }

        public Lute(Serial serial)
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

            if (Weight == 3.0)
            {
                Weight = 5.0;
            }
        }
    }
}
