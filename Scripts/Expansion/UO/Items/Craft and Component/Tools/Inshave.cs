using Server.Engines.Craft;

namespace Server.Items
{
    public class Inshave : BaseTool
    {
        [Constructible]
        public Inshave()
            : base(0x10E6)
        {
            Weight = 1.0;
        }

        [Constructible]
        public Inshave(int uses)
            : base(uses, 0x10E6)
        {
            Weight = 1.0;
        }

        public Inshave(Serial serial)
            : base(serial)
        {
        }

        public override CraftSystem CraftSystem => DefCarpentry.CraftSystem;
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
