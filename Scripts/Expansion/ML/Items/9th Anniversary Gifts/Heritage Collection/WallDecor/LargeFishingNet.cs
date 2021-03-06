using System;

namespace Server.Items
{
    [Flipable(0x3D8E, 0x3D8F)]
    public class LargeFishingNetComponent : AddonComponent
    {
        public LargeFishingNetComponent()
            : base(0x3D8E)
        {
        }

        public LargeFishingNetComponent(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber => 1076285;// Large Fish Net
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }
    }

    public class LargeFishingNetAddon : BaseAddon
    {
        [Constructible]
        public LargeFishingNetAddon()
            : base()
        {
            AddComponent(new LargeFishingNetComponent(), 0, 0, 0);
        }

        public LargeFishingNetAddon(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddonDeed Deed => new LargeFishingNetDeed();
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }
    }

    public class LargeFishingNetDeed : BaseAddonDeed
    {
        [Constructible]
        public LargeFishingNetDeed()
            : base()
        {
            LootType = LootType.Blessed;
        }

        public LargeFishingNetDeed(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddon Addon => new LargeFishingNetAddon();
        public override int LabelNumber => 1076285;// Large Fish Net
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }
    }
}