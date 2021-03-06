namespace Server.Items
{
    public class ClumsyScroll : SpellScroll
    {
        [Constructible]
        public ClumsyScroll()
            : this(1)
        {
        }

        [Constructible]
        public ClumsyScroll(int amount)
            : base(0, 0x1F2E, amount)
        {
        }

        public ClumsyScroll(Serial serial)
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
