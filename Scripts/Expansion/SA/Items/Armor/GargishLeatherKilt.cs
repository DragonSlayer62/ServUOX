using Server.Engines.Craft;
using System;

namespace Server.Items
{
    [TypeAlias("Server.Items.MaleGargishLeatherKilt")]
    public class GargishLeatherKilt : BaseArmor
    {
        [Constructible]
        public GargishLeatherKilt()
            : this(0)
        {
        }

        [Constructible]
        public GargishLeatherKilt(int hue)
            : base(0x311)
        {
            Layer = Layer.Gloves;
            Weight = 5.0;
            Hue = hue;
        }

        public GargishLeatherKilt(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 5;
        public override int BaseFireResistance => 6;
        public override int BaseColdResistance => 7;
        public override int BasePoisonResistance => 6;
        public override int BaseEnergyResistance => 6;

        public override int InitMinHits => 30;
        public override int InitMaxHits => 50;

        public override int AosStrReq => 25;

        public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
        public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
        public override CraftResource DefaultResource => CraftResource.RegularLeather;

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

            if (ItemID != 0x311)
                ItemID = 0x311;
        }
    }
}