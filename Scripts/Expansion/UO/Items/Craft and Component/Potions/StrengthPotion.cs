using System;

namespace Server.Items
{
    public class StrengthPotion : BaseStrengthPotion
    {
        [Constructible]
        public StrengthPotion()
            : base(PotionEffect.Strength)
        {
        }

        public StrengthPotion(Serial serial)
            : base(serial)
        {
        }

        public override int StrOffset => 10;
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
