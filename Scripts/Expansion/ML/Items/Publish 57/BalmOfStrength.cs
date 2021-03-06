using System;
using Server.Mobiles;
using Server;

namespace Server.Items
{
    [TypeAlias("drNO.ThieveItems.BalmOfStrength")]
    public class BalmOfStrength : BaseBalmOrLotion
    {
        public override int LabelNumber => 1094940;  // Balm of Strength

        [Constructible]
        public BalmOfStrength()
            : base(0xEFB)
        {
            m_EffectType = ThieveConsumableEffect.BalmOfStrengthEffect;
        }

        protected override void ApplyEffect(PlayerMobile pm)
        {
            pm.AddStatMod(new StatMod(StatType.Str, "Balm", 10, m_EffectDuration));

            pm.SendLocalizedMessage(1095136); //You apply the balm and suddenly feel stronger!
            base.ApplyEffect(pm);

        }

        public BalmOfStrength(Serial serial)
          : base(serial)
        {
        }


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
