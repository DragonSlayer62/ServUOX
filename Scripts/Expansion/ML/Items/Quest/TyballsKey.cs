using System;

namespace Server.Items
{
    public class TyballsKey : AbyssKey
    {
        [Constructible]
        public TyballsKey()
            : base(0x1012)
        {
            Hue = 0x489;
            Weight = 1.0;
            Name = "Tyball's Key";
            Movable = false;
        }

        public TyballsKey(Serial serial)
            : base(serial)
        {
        }

        // public override int LabelNumber { get { return 1111648; } } //Yellow Key
        public override int Lifespan => 21600;
        public override void OnDoubleClick(Mobile m)
        {
            Item a = m.Backpack.FindItemByType(typeof(RedKey1));
            if (a != null)
            {
                Item b = m.Backpack.FindItemByType(typeof(BlueKey1));
                if (b != null)
                {
                    m.AddToBackpack(new TripartiteKey());
                    a.Delete();
                    b.Delete();
                    Delete();
                    m.SendLocalizedMessage(1111649);
                }
            }
        }

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