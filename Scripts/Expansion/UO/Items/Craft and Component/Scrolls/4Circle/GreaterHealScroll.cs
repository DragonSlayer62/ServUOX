namespace Server.Items
{
    public class GreaterHealScroll : SpellScroll
    {
        [Constructible]
        public GreaterHealScroll()
            : this(1)
        {
        }

        [Constructible]
        public GreaterHealScroll(int amount)
            : base(28, 0x1F49, amount)
        {
        }

        public GreaterHealScroll(Serial serial)
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
