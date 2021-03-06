namespace Server.Items
{
    public class ParalyzeFieldScroll : SpellScroll
    {
        [Constructible]
        public ParalyzeFieldScroll()
            : this(1)
        {
        }

        [Constructible]
        public ParalyzeFieldScroll(int amount)
            : base(46, 0x1F5B, amount)
        {
        }

        public ParalyzeFieldScroll(Serial serial)
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
