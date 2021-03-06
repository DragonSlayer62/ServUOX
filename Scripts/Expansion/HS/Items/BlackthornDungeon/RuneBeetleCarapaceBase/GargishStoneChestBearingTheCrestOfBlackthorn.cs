using Server;
using System;

namespace Server.Items
{
    public class GargishStoneChestBearingTheCrestOfBlackthorn : GargishStoneChest
    {
        public override bool IsArtifact => true;

        [Constructible]
        public GargishStoneChestBearingTheCrestOfBlackthorn()
        {
            ReforgedSuffix = ReforgedSuffix.Blackthorn;
            Hue = 1773;
            Attributes.BonusMana = 10;
            Attributes.RegenMana = 3;
            Attributes.LowerManaCost = 15;
            ArmorAttributes.LowerStatReq = 100;
            ArmorAttributes.MageArmor = 1;
        }

        public override int BasePhysicalResistance => 5;
        public override int BaseFireResistance => 4;
        public override int BaseColdResistance => 14;
        public override int BasePoisonResistance => 3;
        public override int BaseEnergyResistance => 14;
        public override int InitMinHits => 255;
        public override int InitMaxHits => 255;

        public GargishStoneChestBearingTheCrestOfBlackthorn(Serial serial)
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