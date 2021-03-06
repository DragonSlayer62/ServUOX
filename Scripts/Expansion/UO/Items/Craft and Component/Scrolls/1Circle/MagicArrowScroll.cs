namespace Server.Items
{
    public class MagicArrowScroll : SpellScroll
    {
        [Constructible]
        public MagicArrowScroll()
            : this(1)
        {
        }

        [Constructible]
        public MagicArrowScroll(int amount)
            : base(4, 0x1F32, amount)
        {
        }

        public MagicArrowScroll(Serial serial)
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
    }
}
