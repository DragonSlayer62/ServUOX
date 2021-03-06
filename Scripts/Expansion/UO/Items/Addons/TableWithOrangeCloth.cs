namespace Server.Items
{
    public class TableWithOrangeClothAddon : BaseAddon
    {
        [Constructible]
        public TableWithOrangeClothAddon()
            : base()
        {
            AddComponent(new LocalizedAddonComponent(0x118E, 1076278), 0, 0, 0);
        }

        public TableWithOrangeClothAddon(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddonDeed Deed => new TableWithOrangeClothDeed();
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.WriteEncodedInt(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            _ = reader.ReadEncodedInt();
        }
    }

    public class TableWithOrangeClothDeed : BaseAddonDeed
    {
        [Constructible]
        public TableWithOrangeClothDeed()
            : base()
        {
            LootType = LootType.Blessed;
        }

        public TableWithOrangeClothDeed(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddon Addon => new TableWithOrangeClothAddon();
        public override int LabelNumber => 1076278;// Table With An Orange Tablecloth
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.WriteEncodedInt(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            _ = reader.ReadEncodedInt();
        }
    }
}
