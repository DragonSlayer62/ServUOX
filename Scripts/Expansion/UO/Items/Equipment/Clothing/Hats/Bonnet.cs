namespace Server.Items
{
    public class Bonnet : BaseHat
    {
        public override int BasePhysicalResistance => 0;
        public override int BaseFireResistance => 5;
        public override int BaseColdResistance => 9;
        public override int BasePoisonResistance => 5;
        public override int BaseEnergyResistance => 5;

        public override int InitMinHits => 20;
        public override int InitMaxHits => 30;

        [Constructible]
        public Bonnet()
            : this(0)
        {
        }

        [Constructible]
        public Bonnet(int hue)
            : base(0x1719, hue)
        {
            Weight = 1.0;
        }

        public Bonnet(Serial serial)
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
