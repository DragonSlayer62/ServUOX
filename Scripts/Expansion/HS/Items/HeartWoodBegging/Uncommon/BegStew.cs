namespace Server.Items
{
    public class BegStew : WoodenBowlOfStew
    {
        [Constructible]
        public BegStew()
        {
        }

        public BegStew(Serial serial)
            : base(serial)
        {
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            list.Add(1075129); // Acquired by begging
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }
}
