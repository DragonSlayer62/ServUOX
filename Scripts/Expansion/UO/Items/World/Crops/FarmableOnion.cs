namespace Server.Items
{
    public class FarmableOnion : FarmableCrop
    {
        [Constructible]
        public FarmableOnion()
            : base(GetCropID())
        {
        }

        public FarmableOnion(Serial serial)
            : base(serial)
        {
        }

        public static int GetCropID()
        {
            return 3183;
        }

        public override Item GetCropObject()
        {
            Onion onion = new Onion
            {
                ItemID = Utility.Random(3181, 2)
            };

            return onion;
        }

        public override int GetPickedID()
        {
            return 3254;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.WriteEncodedInt(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            _ = reader.ReadEncodedInt();
        }
    }
}
