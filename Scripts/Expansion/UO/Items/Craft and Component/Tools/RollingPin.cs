using Server.Engines.Craft;

namespace Server.Items
{
    public class RollingPin : BaseTool
    {
        [Constructible]
        public RollingPin()
            : base(0x1043)
        {
            Weight = 1.0;
        }

        [Constructible]
        public RollingPin(int uses)
            : base(uses, 0x1043)
        {
            Weight = 1.0;
        }

        public RollingPin(Serial serial)
            : base(serial)
        {
        }

        public override CraftSystem CraftSystem => DefCooking.CraftSystem;
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
