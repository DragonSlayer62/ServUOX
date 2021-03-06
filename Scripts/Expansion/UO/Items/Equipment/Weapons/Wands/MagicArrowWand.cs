using Server.Spells.First;

namespace Server.Items
{
    public class MagicArrowWand : BaseWand
    {
        [Constructible]
        public MagicArrowWand()
            : base(WandEffect.MagicArrow, 5, Core.ML ? 109 : 30)
        {
        }

        public MagicArrowWand(Serial serial)
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

        public override void OnWandUse(Mobile from)
        {
            Cast(new MagicArrowSpell(from, this));
        }
    }
}
