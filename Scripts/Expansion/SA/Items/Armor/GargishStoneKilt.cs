using System;

namespace Server.Items
{
    [TypeAlias("Server.Items.MaleGargishStoneKilt")]
    public class GargishStoneKilt : BaseArmor
    {
        [Constructible]
        public GargishStoneKilt()
            : this(0)
        {
        }

        [Constructible]
        public GargishStoneKilt(int hue)
            : base(0x288)
        {
            Weight = 10.0;
            Hue = hue;
        }

        public GargishStoneKilt(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 6;
        public override int BaseFireResistance => 6;
        public override int BaseColdResistance => 4;
        public override int BasePoisonResistance => 8;
        public override int BaseEnergyResistance => 6;

        public override int InitMinHits => 40;
        public override int InitMaxHits => 50;

        public override int AosStrReq => 40;

        public override ArmorMaterialType MaterialType => ArmorMaterialType.Stone;

        public override Race RequiredRace => Race.Gargoyle;
        public override bool CanBeWornByGargoyles => true;

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