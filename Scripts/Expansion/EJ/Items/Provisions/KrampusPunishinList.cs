namespace Server.Items
{
    [Flipable(0x46AE, 0x46AF)]
    public class KrampusPunishinList : Item
    {
        private string _Name;

        [Constructible]
        public KrampusPunishinList(string name)
            : base(0x46AE)
        {
            _Name = name;
            Hue = 0x21;
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add(1158834, _Name);
        }

        public KrampusPunishinList(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);

            writer.Write(_Name);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            _ = reader.ReadInt();

            _Name = reader.ReadString();
        }
    }
}
