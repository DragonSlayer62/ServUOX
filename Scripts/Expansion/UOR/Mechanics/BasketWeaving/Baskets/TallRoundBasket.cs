using System;
using Server;
using Server.Items;

public class TallRoundBasket : BaseContainer
{
    [Constructible]
    public TallRoundBasket()
        : base(0x24D8)
    {
        Weight = 1.0;
    }

    public TallRoundBasket(Serial serial)
        : base(serial)
    {
    }

    public override int LabelNumber => 1112297;//Tall Round Basket

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