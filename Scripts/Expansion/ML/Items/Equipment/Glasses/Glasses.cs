using System;
using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefTinkering), typeof(GargishGlasses), true)]
    public class Glasses : BaseArmor, IRepairable
    {
        public CraftSystem RepairSystem => DefTinkering.CraftSystem;

        [Constructible]
        public Glasses()
            : base(0x2FB8)
        {
            Weight = 2.0;
        }

        public Glasses(Serial serial)
            : base(serial)
        {
        }

        public override int AosStrReq => 45;
        public override int OldStrReq => 40;
        public override int ArmorBase => 30;

        public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;

        public override CraftResource DefaultResource => CraftResource.RegularLeather;

        public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

        public override bool CanEquip(Mobile m)
        {
            if (m.NetState != null && !m.NetState.SupportsExpansion(Expansion.ML))
            {
                m.SendLocalizedMessage(1072791); // You must upgrade to Mondain's Legacy in order to use that item.

                return false;
            }

            return true;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            if (version == 0)
            {
                XWeaponAttributesDeserializeHelper(reader, this);
            }
        }
    }
}
