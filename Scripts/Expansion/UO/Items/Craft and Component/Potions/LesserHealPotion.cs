namespace Server.Items
{
    public class LesserHealPotion : BaseHealPotion
    {
        [Constructible]
        public LesserHealPotion()
            : base(PotionEffect.HealLesser)
        {
        }

        public LesserHealPotion(Serial serial)
            : base(serial)
        {
        }

        public override int MinHeal => (Core.AOS ? 6 : 3);
        public override int MaxHeal => (Core.AOS ? 8 : 10);
        public override double Delay => (Core.AOS ? 3.0 : 10.0);
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
