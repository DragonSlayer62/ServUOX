namespace Server.Items
{
    public class GrayBrickFireplaceSouthAddon : BaseAddon
    {
        [Constructible]
        public GrayBrickFireplaceSouthAddon()
        {
            AddComponent(new AddonComponent(0x94B), -1, 0, 0);
            AddComponent(new AddonComponent(0x945), 0, 0, 0);
        }

        public GrayBrickFireplaceSouthAddon(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddonDeed Deed => new GrayBrickFireplaceSouthDeed();
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

    public class GrayBrickFireplaceSouthDeed : BaseAddonDeed
    {
        [Constructible]
        public GrayBrickFireplaceSouthDeed()
        {
        }

        public GrayBrickFireplaceSouthDeed(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddon Addon => new GrayBrickFireplaceSouthAddon();
        public override int LabelNumber => 1061847;// grey brick fireplace (south)
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
