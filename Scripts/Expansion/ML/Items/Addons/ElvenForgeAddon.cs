using System;

namespace Server.Items
{
    public class ElvenForgeAddon : BaseAddon
    {
        [Constructible]
        public ElvenForgeAddon()
        {
            AddComponent(new ForgeComponent(0x2DD8), 0, 0, 0);
        }

        public ElvenForgeAddon(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddonDeed Deed => new ElvenForgeDeed();
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

    public class ElvenForgeDeed : BaseAddonDeed
    {
        [Constructible]
        public ElvenForgeDeed()
        {
        }

        public ElvenForgeDeed(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddon Addon => new ElvenForgeAddon();
        public override int LabelNumber => 1072875;// squirrel statue (east)
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