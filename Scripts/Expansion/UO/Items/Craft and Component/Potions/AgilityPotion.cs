using System;

namespace Server.Items
{
    public class AgilityPotion : BaseAgilityPotion
    {
        [Constructible]
        public AgilityPotion()
            : base(PotionEffect.Agility)
        {
        }

        public AgilityPotion(Serial serial)
            : base(serial)
        {
        }

        public override int DexOffset => 10;
        public override TimeSpan Duration => TimeSpan.FromMinutes(2.0);
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
