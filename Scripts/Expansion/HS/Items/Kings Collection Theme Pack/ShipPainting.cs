using System;
using Server.Gumps;
using Server.Multis;

namespace Server.Items
{
    public class ShipPaintingAddon : BaseAddon
    {
        public override bool ForceShowProperties => true;

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime NextResourceCount { get; set; }

        private int m_ResourceCount;

        [CommandProperty(AccessLevel.GameMaster)]
        public int ResourceCount { get { return m_ResourceCount; } set { m_ResourceCount = value; UpdateProperties(); } }

        [Constructible]
        public ShipPaintingAddon(DirectionType type)
           : this(type, 0, DateTime.UtcNow + TimeSpan.FromDays(7))
        {
        }

        [Constructible]
        public ShipPaintingAddon(DirectionType type, int resCount, DateTime nextuse)
        {
            NextResourceCount = nextuse;
            ResourceCount = resCount;

            switch (type)
            {
                case DirectionType.East:
                    AddComponent(new LocalizedAddonComponent(0x4C27, 1098378), 0, 0, 0);
                    break;
                case DirectionType.South:
                    AddComponent(new LocalizedAddonComponent(0x4C26, 1098378), 0, 0, 0);
                    break;
            }
        }

        public ShipPaintingAddon(Serial serial)
            : base(serial)
        {
        }

        public override void OnComponentUsed(AddonComponent component, Mobile from)
        {
            BaseHouse house = BaseHouse.FindHouseAt(from);

            if (house != null && (house.IsOwner(from) || (house.LockDowns.ContainsKey(this) && house.LockDowns[this] == from)))
            {
                if (ResourceCount > 0)
                {
                    ResourceCount--;
                    Item item = new HeavyPowderCharge();

                    from.AddToBackpack(item);
                    from.SendLocalizedMessage(1154174); // Powder charges have been placed in your backpack.
                }
            }
            else
            {
                from.SendLocalizedMessage(502092); // You must be in your house to do this.
            }
        }

        public override BaseAddonDeed Deed => new ShipPaintingDeed();

        private class ShipPaintingComponent : LocalizedAddonComponent
        {
            public ShipPaintingComponent(int id)
                : base(id, 1098378) // painting
            {
            }

            public override void GetProperties(ObjectPropertyList list)
            {
                base.GetProperties(list);

                if (Addon is ShipPaintingAddon)
                {
                    list.Add(1154175, ((ShipPaintingAddon)Addon).ResourceCount.ToString()); // Powder Charges: ~1_COUNT~
                }
            }

            public ShipPaintingComponent(Serial serial)
                : base(serial)
            {
            }

            public override void Serialize(GenericWriter writer)
            {
                base.Serialize(writer);
                writer.Write(0); // Version
            }

            public override void Deserialize(GenericReader reader)
            {
                base.Deserialize(reader);
                int version = reader.ReadInt();
            }
        }

        private void TryGiveResourceCount()
        {
            if (NextResourceCount < DateTime.UtcNow)
            {
                ResourceCount = Math.Min(210, m_ResourceCount + 42);
                NextResourceCount = DateTime.UtcNow + TimeSpan.FromDays(7);

                UpdateProperties();
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);

            TryGiveResourceCount();

            writer.Write(m_ResourceCount);
            writer.Write(NextResourceCount);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            m_ResourceCount = reader.ReadInt();
            NextResourceCount = reader.ReadDateTime();
        }
    }

    public class ShipPaintingDeed : BaseAddonDeed, IRewardOption
    {
        public override int LabelNumber => 1154180;  // Ship Painting 

        private DirectionType _Direction;

        [Constructible]
        public ShipPaintingDeed()
            : base()
        {
            LootType = LootType.Blessed;
        }

        public ShipPaintingDeed(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (IsChildOf(from.Backpack))
            {
                from.CloseGump(typeof(AddonOptionGump));
                from.SendGump(new AddonOptionGump(this, 1154194)); // Choose a Facing:
            }
            else
            {
                from.SendLocalizedMessage(1062334); // This item must be in your backpack to be used.
            }
        }

        public void GetOptions(RewardOptionList list)
        {
            list.Add((int)DirectionType.South, 1075386); // South
            list.Add((int)DirectionType.East, 1075387); // East
        }

        public void OnOptionSelected(Mobile from, int choice)
        {
            _Direction = (DirectionType)choice;

            if (!Deleted)
                base.OnDoubleClick(from);
        }

        public override BaseAddon Addon => new ShipPaintingAddon(_Direction);

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
