namespace Server.Items
{
    public class TwilightLantern : Lantern
    {
        [Constructible]
        public TwilightLantern()
            : base()
        {
            Hue = Utility.RandomBool() ? 142 : 947;
        }

        public TwilightLantern(Serial serial)
            : base(serial)
        {
        }

        public override string DefaultName => "Twilight Lantern";
        public override bool AllowEquipedCast(Mobile from)
        {
            return true;
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            list.Add(1060482); // Spell Channeling
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
