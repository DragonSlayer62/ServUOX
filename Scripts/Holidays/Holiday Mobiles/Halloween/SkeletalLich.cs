using System;
using Server;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a skeletal corpse")]
    public class SkeletalLich : BaseCreature
    {
        [Constructible]
        public SkeletalLich() : base(AIType.AI_NecroMage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a skeletal lich";
            Body = 309;
            Hue = 1345;
            BaseSoundID = 0x48D;

            SetStr(301, 350);
            SetDex(75);
            SetInt(151, 200);

            SetHits(1200);
            SetStam(150);
            SetMana(0);

            SetDamage(8, 10);

            SetDamageType(ResistType.Physical, 0);
            SetDamageType(ResistType.Cold, 50);
            SetDamageType(ResistType.Poison, 50);

            SetResist(ResistType.Physical, 35, 45);
            SetResist(ResistType.Fire, 20, 30);
            SetResist(ResistType.Cold, 50, 70);
            SetResist(ResistType.Poison, 40, 50);
            SetResist(ResistType.Energy, 20, 30);

            SetSkill(SkillName.EvalInt, 127.2);
            SetSkill(SkillName.Magery, 127.2);
            SetSkill(SkillName.Necromancy, 100.0, 120.0);
            SetSkill(SkillName.MagicResist, 187.1);
            SetSkill(SkillName.Tactics, 91.7);
            SetSkill(SkillName.Wrestling, 98.5);

            Fame = 6000;
            Karma = -6000;

            VirtualArmor = 40;
            SetWeaponAbility(WeaponAbility.Dismount);
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich, 2);
        }

        public override bool BleedImmunity => true;
        public override Poison PoisonImmunity => Poison.Lethal;

        public override int TreasureMapLevel => 1;

        public SkeletalLich(Serial serial) : base(serial)
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
            int version = reader.ReadInt();
        }
    }
}