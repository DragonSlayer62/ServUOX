using System;

namespace Server.Items
{
    public class GargishBracelet : BaseBracelet
    {
        [Constructible]
        public GargishBracelet()
            : base(0x4211)
        {
            //Weight = 0.1;
        }

        public GargishBracelet(Serial serial)
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