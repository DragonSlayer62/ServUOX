namespace Server.Items
{
    [Flipable(0xe43, 0xe42)]
    public class WoodenTreasureChest : BaseTreasureChest
    {
        [Constructible]
        public WoodenTreasureChest()
            : base(0xE43)
        {
        }

        public WoodenTreasureChest(Serial serial)
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

    [Flipable(0xe41, 0xe40)]
    public class MetalGoldenTreasureChest : BaseTreasureChest
    {
        [Constructible]
        public MetalGoldenTreasureChest()
            : base(0xE41)
        {
        }

        public MetalGoldenTreasureChest(Serial serial)
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

    [Flipable(0x9ab, 0xe7c)]
    public class MetalTreasureChest : BaseTreasureChest
    {
        [Constructible]
        public MetalTreasureChest()
            : base(0x9AB)
        {
        }

        public MetalTreasureChest(Serial serial)
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
