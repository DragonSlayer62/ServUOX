using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a minotaur general corpse")]
    public class MinotaurGeneral : MinotaurCaptain
    {
        [Constructible]
        public MinotaurGeneral()
        {
            Name = "a minotaur general";
            Body = 0x118;

            SetStr(602, 606);
            SetDex(137, 139);
            SetInt(83, 96);

            SetHits(1006, 1041);

            SetDamage(16, 22);

            SetDamageType(ResistType.Physical, 40);
            SetDamageType(ResistType.Cold, 20);
            SetDamageType(ResistType.Poison, 20);
            SetDamageType(ResistType.Energy, 20);

            SetResist(ResistType.Physical, 77, 80);
            SetResist(ResistType.Fire, 59, 64);
            SetResist(ResistType.Cold, 63, 68);
            SetResist(ResistType.Poison, 61, 66);
            SetResist(ResistType.Energy, 63, 66);

            SetSkill(SkillName.Wrestling, 101.0, 129.7);
            SetSkill(SkillName.Tactics, 92.0, 104.8);
            SetSkill(SkillName.MagicResist, 86.0, 87.0);

            Fame = 18000;
            Karma = -18000;

            for (int i = 0; i < Utility.RandomMinMax(0, 1); i++)
            {
                PackItem(Loot.RandomScroll(0, Loot.ArcanistScrollTypes.Length, SpellbookType.Arcanist));
            }
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich, 2);
        }

        public override int TreasureMapLevel => 4;

        public MinotaurGeneral(Serial serial)
            : base(serial)
        {
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