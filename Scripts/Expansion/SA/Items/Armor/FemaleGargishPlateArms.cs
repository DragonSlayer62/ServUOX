using System;

namespace Server.Items
{
    public class FemaleGargishPlateArms : BaseArmor
    {
        [Constructible]
        public FemaleGargishPlateArms()
            : this(0)
        {
        }

        [Constructible]
        public FemaleGargishPlateArms(int hue)
            : base(0x307)
        {
            Weight = 5.0;
            Hue = hue;
        }

        public FemaleGargishPlateArms(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 8;
        public override int BaseFireResistance => 6;
        public override int BaseColdResistance => 5;
        public override int BasePoisonResistance => 6;
        public override int BaseEnergyResistance => 5;

        public override int InitMinHits => 50;
        public override int InitMaxHits => 65;

        public override int AosStrReq => 80;

        public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

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