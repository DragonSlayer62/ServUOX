using System;

namespace Server.Items
{
    public class NecromancerSpellbook : Spellbook
    {
        [Constructible]
        public NecromancerSpellbook()
            : this((ulong)0)
        {
        }

        [Constructible]
        public NecromancerSpellbook(ulong content)
            : base(content, 0x2253)
        {
            Layer = (Core.ML ? Layer.OneHanded : Layer.Invalid);
        }

        public NecromancerSpellbook(Serial serial)
            : base(serial)
        {
        }

        public override SpellbookType SpellbookType => SpellbookType.Necromancer;
        public override int BookOffset => 100;
        public override int BookCount => ((Core.SE) ? 17 : 16);
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(1); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (version == 0 && Core.ML)
                Layer = Layer.OneHanded;
        }
    }

    public class CompleteNecromancerSpellbook : NecromancerSpellbook
    {
        [Constructible]
        public CompleteNecromancerSpellbook()
            : base((ulong)0x1FFFF)
        {
        }

        public CompleteNecromancerSpellbook(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }
    }
}