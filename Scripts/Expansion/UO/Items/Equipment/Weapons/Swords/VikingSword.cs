using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(StoneWarSword))]
    [Flipable(0x13B9, 0x13Ba)]
    public class VikingSword : BaseSword
    {
        [Constructible]
        public VikingSword()
            : base(0x13B9)
        {
            Weight = 6.0;
        }

        public VikingSword(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
        public override WeaponAbility SecondaryAbility => WeaponAbility.ParalyzingBlow;
        public override int AosStrengthReq => 40;
        public override int AosMinDamage => 15;
        public override int AosMaxDamage => 19;
        public override int AosSpeed => 28;
        public override float MlSpeed => 3.75f;
        public override int OldStrengthReq => 40;
        public override int OldMinDamage => 6;
        public override int OldMaxDamage => 34;
        public override int OldSpeed => 30;
        public override int DefHitSound => 0x237;
        public override int DefMissSound => 0x23A;
        public override int InitMinHits => 31;
        public override int InitMaxHits => 100;
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
