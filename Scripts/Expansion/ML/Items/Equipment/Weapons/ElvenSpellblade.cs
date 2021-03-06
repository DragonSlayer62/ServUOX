using System;
using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(DualPointedSpear))]
    [Flipable(0x2D20, 0x2D2C)]
    public class ElvenSpellblade : BaseKnife
    {
        [Constructible]
        public ElvenSpellblade()
            : base(0x2D20)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
        }

        public ElvenSpellblade(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.PsychicAttack;
        public override WeaponAbility SecondaryAbility => WeaponAbility.BleedAttack;
        public override int AosStrengthReq => 35;
        public override int AosMinDamage => 12;
        public override int AosMaxDamage => 15;
        public override int AosSpeed => 44;
        public override float MlSpeed => 2.50f;
        public override int OldStrengthReq => 35;
        public override int OldMinDamage => 12;
        public override int OldMaxDamage => 14;
        public override int OldSpeed => 44;
        public override int DefMissSound => 0x239;
        public override int InitMinHits => 30;
        public override int InitMaxHits => 60;
        public override SkillName DefSkill => SkillName.Fencing;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }
    }
}
