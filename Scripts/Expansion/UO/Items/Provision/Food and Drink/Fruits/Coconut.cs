
namespace Server.Items
{
    public class Coconut : Food
    {
        [Constructible]
        public Coconut()
            : this(1)
        {
        }

        [Constructible]
        public Coconut(int amount)
            : base(amount, 0x1726)
        {
            Weight = 1.0;
            FillFactor = 1;
        }

        public Coconut(Serial serial)
            : base(serial)
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
            _ = reader.ReadInt();
        }
    }
}
