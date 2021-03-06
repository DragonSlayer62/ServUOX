namespace Server.Items
{
    public class AnimateDeadScroll : SpellScroll
    {
        [Constructible]
        public AnimateDeadScroll()
            : this(1)
        {
        }

        [Constructible]
        public AnimateDeadScroll(int amount)
            : base(100, 0x2260, amount)
        {
        }

        public AnimateDeadScroll(Serial serial)
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
