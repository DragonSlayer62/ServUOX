namespace Server.Items
{
    public class HoodedBritanniaRobe : BaseOuterTorso
    {
        public override int LabelNumber => 1125155;  // Hooded Britannia Robe

        [Constructible]
        public HoodedBritanniaRobe(int id)
            : base(id)
        {
            LootType = LootType.Blessed;
        }

        public HoodedBritanniaRobe(Serial serial)
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

            int version = reader.ReadInt();
        }
    }
}
