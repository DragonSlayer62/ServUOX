namespace Server.Items
{
    public class WaterTroughSouthAddon : BaseAddon, IWaterSource
    {
        [Constructible]
        public WaterTroughSouthAddon()
        {
            AddComponent(new AddonComponent(0xB43), 0, 0, 0);
            AddComponent(new AddonComponent(0xB44), 1, 0, 0);
        }

        public WaterTroughSouthAddon(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddonDeed Deed => new WaterTroughSouthDeed();
        public int Quantity
        {
            get => 500;
            set
            {
            }
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

    public class WaterTroughSouthDeed : BaseAddonDeed
    {
        [Constructible]
        public WaterTroughSouthDeed()
        {
        }

        public WaterTroughSouthDeed(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddon Addon => new WaterTroughSouthAddon();
        public override int LabelNumber => 1044350;// water trough (south)
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
