using System;

namespace Server.Items
{
    public class MeagerMuseumBag : BaseRewardBag
    {
        [Constructible]
        public MeagerMuseumBag()
        {
            DropItem(new Gold(3000));
            DropItem(new TerMurQuestRewardBook());

            for (int i = 0; i < Utility.RandomMinMax(5, 7); i++)
            {
                DropItemStacked(Loot.RandomGem());
            }

            for (int i = 0; i < Utility.RandomMinMax(1, 3); i++)
            {
                DropItemStacked(Loot.RandomMLResource());
            }
        }

        public MeagerMuseumBag(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber => 1112993;
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
}
