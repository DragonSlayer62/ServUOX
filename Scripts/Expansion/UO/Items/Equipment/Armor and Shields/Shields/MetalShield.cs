using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(MediumPlateShield))]
    public class MetalShield : BaseShield
    {
        [Constructible]
        public MetalShield()
            : base(0x1B7B)
        {
            Weight = 6.0;
        }

        public MetalShield(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 0;
        public override int BaseFireResistance => 1;
        public override int BaseColdResistance => 0;
        public override int BasePoisonResistance => 0;
        public override int BaseEnergyResistance => 0;
        public override int InitMinHits => 50;
        public override int InitMaxHits => 65;
        public override int AosStrReq => 45;
        public override int ArmorBase => 11;

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
