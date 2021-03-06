
namespace Server.Items
{
    public class Lemon : Food
    {
        [Constructible]
        public Lemon()
            : this(1)
        {
        }

        [Constructible]
        public Lemon(int amount)
            : base(amount, 0x1728)
        {
            Weight = 1.0;
            FillFactor = 1;
        }

        public Lemon(Serial serial)
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
