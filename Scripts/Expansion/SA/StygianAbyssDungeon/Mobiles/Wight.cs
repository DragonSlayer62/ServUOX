/* Based on Wailing Banshee, still no infos on Wight, including correct body ID */
using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a wight corpse")]
    public class Wight : BaseCreature
    {
        [Constructible]
        public Wight()
            : base(AIType.AI_NecroMage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a Wight";
            Body = 252;
            Hue = 1153;
            BaseSoundID = 0x482;

            SetStr(150, 200);
            SetDex(50, 60);
            SetInt(150, 200);

            SetHits(150, 250);

            SetDamage(13, 20);

            SetDamageType(ResistType.Physical, 20);
            SetDamageType(ResistType.Cold, 80);

            SetResist(ResistType.Physical, 35, 45);
            SetResist(ResistType.Fire, 30, 40);
            SetResist(ResistType.Cold, 50, 60);
            SetResist(ResistType.Poison, 40, 50);
            SetResist(ResistType.Energy, 50, 60);

            SetSkill(SkillName.MagicResist, 40.0, 50.0);
            SetSkill(SkillName.Tactics, 45.0, 55.0);
            SetSkill(SkillName.Wrestling, 50.0, 60.0);
            SetSkill(SkillName.Magery, 60.0, 80.0);
            SetSkill(SkillName.Meditation, 50.0, 60.0);
            SetSkill(SkillName.Necromancy, 40.0, 69.3);
            SetSkill(SkillName.SpiritSpeak, 40.8, 68.9);

            Fame = 1500;
            Karma = -1500;

            VirtualArmor = 19;

            SetWeaponAbility(WeaponAbility.MortalStrike);
            SetWeaponAbility(WeaponAbility.ColdWind);
        }

        public Wight(Serial serial)
            : base(serial)
        {
        }

        public override bool BleedImmunity => true;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Meager);
        }

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