using System;

namespace Server.Items
{
    [Flipable(0x450D, 0x450D)]
    public class GargoyleTailMale : BaseWaist
    {
        [Constructible]
        public GargoyleTailMale()
            : this(0)
        {
        }

        [Constructible]
        public GargoyleTailMale(int hue)
            : base(0x450D, hue)
        {
            Weight = 2.0;
        }

        public GargoyleTailMale(Serial serial)
            : base(serial)
        {
        }

        public override Race RequiredRace => Race.Gargoyle;
        public override bool CanBeWornByGargoyles => true;
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

    [Flipable(0x44C1, 0x44C2)]
    public class GargoyleTailFemale : BaseWaist
    {
        [Constructible]
        public GargoyleTailFemale()
            : this(0)
        {
        }

        [Constructible]
        public GargoyleTailFemale(int hue)
            : base(0x44C1, hue)
        {
            Weight = 2.0;
        }

        public GargoyleTailFemale(Serial serial)
            : base(serial)
        {
        }

        public override Race RequiredRace => Race.Gargoyle;
        public override bool CanBeWornByGargoyles => true;
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