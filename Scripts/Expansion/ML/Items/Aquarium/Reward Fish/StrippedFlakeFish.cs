namespace Server.Items
{
    public class StrippedFlakeFish : BaseFish
    {
        [Constructible]
        public StrippedFlakeFish()
            : base(0x3B0A)
        {
        }

        public StrippedFlakeFish(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber => 1074595;// Stripped Flake Fish
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
