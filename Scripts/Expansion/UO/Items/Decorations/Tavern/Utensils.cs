using Server.Engines.Craft;
using System;

namespace Server.Items
{
    public class BaseUtensil : Item, IResource, IQuality
    {
        private CraftResource _Resource;
        private Mobile _Crafter;
        private ItemQuality _Quality;

        [CommandProperty(AccessLevel.GameMaster)]
        public CraftResource Resource { get => _Resource; set { _Resource = value; Hue = CraftResources.GetHue(_Resource); InvalidateProperties(); } }

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Crafter { get => _Crafter; set { _Crafter = value; InvalidateProperties(); } }

        [CommandProperty(AccessLevel.GameMaster)]
        public ItemQuality Quality { get => _Quality; set { _Quality = value; InvalidateProperties(); } }

        public bool PlayerConstructed => true;

        #region Old Item Serialization Vars
        /* DO NOT USE! Only used in serialization of special scrolls that originally derived from Item */

        protected bool InheritsItem { get; private set; }
        #endregion

        public BaseUtensil(int itemID)
            : base(itemID)
        {
        }

        public override void AddCraftedProperties(ObjectPropertyList list)
        {
            if (_Crafter != null)
            {
                list.Add(1050043, _Crafter.TitleName); // crafted by ~1_NAME~
            }

            if (_Quality == ItemQuality.Exceptional)
            {
                list.Add(1060636); // Exceptional
            }
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            if (_Resource > CraftResource.Iron)
            {
                list.Add(1053099, "#{0}\t{1}", CraftResources.GetLocalizationNumber(_Resource), $"#{LabelNumber.ToString()}"); // ~1_oretype~ ~2_armortype~
            }
            else
            {
                base.AddNameProperty(list);
            }
        }

        public virtual int OnCraft(int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, ITool tool, CraftItem craftItem, int resHue)
        {
            Quality = (ItemQuality)quality;

            if (makersMark)
            {
                Crafter = from;
            }

            if (!craftItem.ForceNonExceptional)
            {
                if (typeRes == null)
                {
                    typeRes = craftItem.Resources.GetAt(0).ItemType;
                }

                Resource = CraftResources.GetFromType(typeRes);
            }

            return quality;
        }

        public BaseUtensil(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(1);

            writer.Write((int)_Resource);
            writer.Write(_Crafter);
            writer.Write((int)_Quality);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    _Resource = (CraftResource)reader.ReadInt();
                    _Crafter = reader.ReadMobile();
                    _Quality = (ItemQuality)reader.ReadInt();

                    break;
                case 0:
                    InheritsItem = true;
                    break;
            }
        }
    }

    [Flipable(0x9F4, 0x9F5, 0x9A3, 0x9A4)]
    public class Fork : BaseUtensil
    {
        [Constructible]
        public Fork()
            : base(0x9F4)
        {
            Weight = 1.0;
        }

        public Fork(Serial serial)
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
            _ = InheritsItem ? 0 : reader.ReadInt();
        }
    }

    public class ForkLeft : BaseUtensil
    {
        [Constructible]
        public ForkLeft()
            : base(0x9F4)
        {
            Weight = 1.0;
        }

        public ForkLeft(Serial serial)
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
            _ = InheritsItem ? 0 : reader.ReadInt();
        }
    }

    public class ForkRight : BaseUtensil
    {
        [Constructible]
        public ForkRight()
            : base(0x9F5)
        {
            Weight = 1.0;
        }

        public ForkRight(Serial serial)
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
            _ = InheritsItem ? 0 : reader.ReadInt();
        }
    }

    [Flipable(0x9F8, 0x9F9, 0x9C2, 0x9C3)]
    public class Spoon : BaseUtensil
    {
        [Constructible]
        public Spoon()
            : base(0x9F8)
        {
            Weight = 1.0;
        }

        public Spoon(Serial serial)
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
            _ = InheritsItem ? 0 : reader.ReadInt();
        }
    }

    public class SpoonLeft : BaseUtensil
    {
        [Constructible]
        public SpoonLeft()
            : base(0x9F8)
        {
            Weight = 1.0;
        }

        public SpoonLeft(Serial serial)
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
            _ = InheritsItem ? 0 : reader.ReadInt();
        }
    }

    public class SpoonRight : BaseUtensil
    {
        [Constructible]
        public SpoonRight()
            : base(0x9F9)
        {
            Weight = 1.0;
        }

        public SpoonRight(Serial serial)
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
            _ = InheritsItem ? 0 : reader.ReadInt();
        }
    }

    [Flipable(0x9F6, 0x9F7, 0x9A5, 0x9A6)]
    public class Knife : BaseUtensil
    {
        [Constructible]
        public Knife()
            : base(0x9F6)
        {
            Weight = 1.0;
        }

        public Knife(Serial serial)
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
            _ = InheritsItem ? 0 : reader.ReadInt();
        }
    }

    public class KnifeLeft : BaseUtensil
    {
        [Constructible]
        public KnifeLeft()
            : base(0x9F6)
        {
            Weight = 1.0;
        }

        public KnifeLeft(Serial serial)
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
            _ = InheritsItem ? 0 : reader.ReadInt();
        }
    }

    public class KnifeRight : BaseUtensil
    {
        [Constructible]
        public KnifeRight()
            : base(0x9F7)
        {
            Weight = 1.0;
        }

        public KnifeRight(Serial serial)
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
            _ = InheritsItem ? 0 : reader.ReadInt();
        }
    }

    public class Plate : BaseUtensil
    {
        [Constructible]
        public Plate()
            : base(0x9D7)
        {
            Weight = 1.0;
        }

        public Plate(Serial serial)
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
            _ = InheritsItem ? 0 : reader.ReadInt();
        }
    }
}
