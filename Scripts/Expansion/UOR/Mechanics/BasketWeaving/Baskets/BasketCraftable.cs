using System;
using Server;

namespace Server.Items
{
    public class BasketCraftable : BaseContainer
    {
        public override int LabelNumber => 1022448;  //basket

        [Constructible]
        public BasketCraftable() : base(9431)
        {
        }

        public BasketCraftable(Serial serial) : base(serial)
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
            int v = reader.ReadInt();
        }
    }
}