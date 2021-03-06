using System;
using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(DualPointedSpear))]
    [Flipable(0x26BF, 0x26C9)]
    public class DoubleBladedStaff : BaseSpear
    {
        [Constructible]
        public DoubleBladedStaff()
            : base(0x26BF)
        {
            Weight = 2.0;
        }

        public DoubleBladedStaff(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
        public override WeaponAbility SecondaryAbility => WeaponAbility.InfectiousStrike;
        public override int AosStrengthReq => 50;
        public override int AosMinDamage => 11;
        public override int AosMaxDamage => 14;
        public override int AosSpeed => 49;
        public override float MlSpeed => 2.25f;
        public override int OldStrengthReq => 50;
        public override int OldMinDamage => 12;
        public override int OldMaxDamage => 13;
        public override int OldSpeed => 49;
        public override int InitMinHits => 31;
        public override int InitMaxHits => 80;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}