using System;
using Server;
using Server.Items;

public class TallBasket : BaseContainer
{
    [Constructible]
    public TallBasket()
        : base(0x24DB)
    {
        Weight = 1.0;
    }

    public TallBasket(Serial serial)
        : base(serial)
    {
    }

    public override int LabelNumber => 1112299;// tall basket

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