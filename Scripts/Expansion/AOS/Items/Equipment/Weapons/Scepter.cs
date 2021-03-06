using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(DiscMace))]
    [Flipable(0x26BC, 0x26C6)]
    public class Scepter : BaseBashing
    {
        [Constructible]
        public Scepter()
            : base(0x26BC)
        {
            Weight = 8.0;
        }

        public Scepter(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
        public override WeaponAbility SecondaryAbility => WeaponAbility.MortalStrike;
        public override int AosStrengthReq => 40;
        public override int AosMinDamage => 14;
        public override int AosMaxDamage => 18;
        public override int AosSpeed => 30;
        public override float MlSpeed => 3.50f;
        public override int OldStrengthReq => 40;
        public override int OldMinDamage => 14;
        public override int OldMaxDamage => 17;
        public override int OldSpeed => 30;
        public override int InitMinHits => 31;
        public override int InitMaxHits => 110;
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
