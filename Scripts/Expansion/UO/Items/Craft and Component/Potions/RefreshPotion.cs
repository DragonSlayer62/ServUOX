namespace Server.Items
{
    public class RefreshPotion : BaseRefreshPotion
    {
        [Constructible]
        public RefreshPotion()
            : base(PotionEffect.Refresh)
        {
        }

        public RefreshPotion(Serial serial)
            : base(serial)
        {
        }

        public override double Refresh => 0.25;
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
