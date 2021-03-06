using System;

namespace Server.Items
{
    [Flipable(0x42DE, 0x42DF)]
    public class PlateTalons : BaseShoes
    {
        [Constructible]
        public PlateTalons()
            : this(0)
        {
        }

        [Constructible]
        public PlateTalons(int hue)
            : base(0x42DE, hue)
        {
            Weight = 5.0;
        }

        public PlateTalons(Serial serial)
            : base(serial)
        {
        }

        public override Race RequiredRace => Race.Gargoyle;
        public override bool CanBeWornByGargoyles => true;
        public override CraftResource DefaultResource => CraftResource.Iron;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}