using System;
using Server.Mobiles;
using Server.Spells.Ninjitsu;

namespace Server.Items
{
    public enum TalismanForm
    {
        Ferret = 1031672,
        Squirrel = 1031671,
        CuSidhe = 1031670,
        Reptalon = 1075202
    }

    public class BaseFormTalisman : Item
    {
        public BaseFormTalisman()
            : base(0x2F59)
        {
            LootType = LootType.Blessed;
            Layer = Layer.Talisman;
            Weight = 1.0;
        }

        public BaseFormTalisman(Serial serial)
            : base(serial)
        {
        }

        public virtual TalismanForm Form => TalismanForm.Squirrel;

        public static bool EntryEnabled(Mobile m, Type type)
        {
            if (type == typeof(Squirrel))
                return m.Talisman is SquirrelFormTalisman;
            else if (type == typeof(Ferret))
                return m.Talisman is FerretFormTalisman;
            else if (type == typeof(CuSidhe))
                return m.Talisman is CuSidheFormTalisman;
            else if (type == typeof(Reptalon))
                return m.Talisman is ReptalonFormTalisman;

            return true;
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add(1075200, string.Format("#{0}", (int)Form));
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

        public override void OnRemoved(object parent)
        {
            base.OnRemoved(parent);

            if (parent is Mobile m)
            {
                AnimalForm.RemoveContext(m, true);
            }
        }
    }
}
