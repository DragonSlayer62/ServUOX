using System;

namespace Server.Items
{
    public class AdventurersMachete : ElvenMachete
    {
        public override bool IsArtifact => true;
        [Constructible]
        public AdventurersMachete()
        {
            Attributes.Luck = 20;
        }

        public AdventurersMachete(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber => 1073533;// adventurer's machete
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