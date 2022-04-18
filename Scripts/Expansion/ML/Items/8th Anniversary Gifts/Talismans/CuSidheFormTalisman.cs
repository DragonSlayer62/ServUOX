namespace Server.Items
{
    public class CuSidheFormTalisman : BaseFormTalisman
    {
        public override TalismanForm Form => TalismanForm.CuSidhe;

        [Constructible]
        public CuSidheFormTalisman()
            : base()
        {
        }

        public CuSidheFormTalisman(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.WriteEncodedInt(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            _ = reader.ReadEncodedInt();
        }
    }
}
