using Server.Engines.Craft;

namespace Server.Items
{
    public class VirtueShield : BaseShield, IRepairable
    {
        public CraftSystem RepairSystem => DefBlacksmithy.CraftSystem;
        public override int BasePhysicalResistance => 8;
        public override int BaseFireResistance => 8;
        public override int BaseColdResistance => 8;
        public override int BasePoisonResistance => 8;
        public override int BaseEnergyResistance => 8;

        public override bool CanBeWornByGargoyles => true;
        public override int LabelNumber => 1109616;  // Virtue Shield

        public override int InitMinHits => 255;
        public override int InitMaxHits => 255;
        public override bool IsArtifact => true;

        [Constructible]
        public VirtueShield()
            : base(0x7818)
        {
            Attributes.SpellChanneling = 1;
            Attributes.DefendChance = 10;

            LootType = LootType.Blessed;
        }

        public override bool OnEquip(Mobile from)
        {
            bool yes = base.OnEquip(from);

            if (yes)
            {
                Effects.PlaySound(from.Location, from.Map, 0x1F7);
                from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);
            }

            return yes;
        }

        public VirtueShield(Serial serial)
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
