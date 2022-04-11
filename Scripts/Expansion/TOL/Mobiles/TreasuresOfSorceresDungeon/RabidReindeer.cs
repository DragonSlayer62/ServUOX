using System;

using Server.Mobiles;

namespace Server.Engines.SorcerersDungeon
{
    [CorpseName("a rabid reindeers corpse")]
    public class RabidReindeer : BaseCreature
    {
        [Constructible]
        public RabidReindeer()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a rabid reindeer";

            Body = 0xEA;
            Hue = 2707;

            SetStr(800);
            SetDex(150);
            SetInt(1200);

            SetHits(8000);

            SetDamage(22, 29);

            SetDamageType(ResistType.Physical, 50);
            SetDamageType(ResistType.Cold, 50);

            SetResist(ResistType.Physical, 60, 70);
            SetResist(ResistType.Fire, 40, 50);
            SetResist(ResistType.Cold, 100);
            SetResist(ResistType.Poison, 60, 70);
            SetResist(ResistType.Energy, 60, 70);

            SetSkill(SkillName.Anatomy, 115, 120);
            SetSkill(SkillName.Poisoning, 120);
            SetSkill(SkillName.MagicResist, 115, 120);
            SetSkill(SkillName.Tactics, 100.0);
            SetSkill(SkillName.Wrestling, 120, 130);

            Fame = 12000;
            Karma = -12000;

            SetSpecialAbility(SpecialAbility.VenomousBite);
        }

        public override int Meat => 6;
        public override int Hides => 15;

        public override int GetAttackSound()
        {
            return 0x82;
        }

        public override int GetHurtSound()
        {
            return 0x83;
        }

        public override int GetDeathSound()
        {
            return 0x84;
        }

        public RabidReindeer(Serial serial)
            : base(serial)
        {
        }

        public override Poison HitPoison => Poison.Lethal;
        public override bool AlwaysMurderer => true;
        public override Poison PoisonImmunity => Poison.Lethal;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich, 2);
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
