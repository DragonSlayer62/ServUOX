using System;

namespace Server.Mobiles
{
    [CorpseName("a lifestealer corpse")]
    public class Lifestealer : BaseCreature
    {
        [Constructible]
        public Lifestealer()
            : base(AIType.AI_NecroMage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a lifestealer";
            Body = 303;
            Hue = 2606;
            BaseSoundID = 357;

            SetStr(200, 240);
            SetDex(130, 150);
            SetInt(200, 250);

            SetHits(4600, 4650);

            SetDamage(22, 26);

            SetDamageType(ResistType.Physical, 50);
            SetDamageType(ResistType.Fire, 10);
            SetDamageType(ResistType.Cold, 20);
            SetDamageType(ResistType.Energy, 20);

            SetResist(ResistType.Physical, 45, 55);
            SetResist(ResistType.Fire, 25, 35);
            SetResist(ResistType.Cold, 15, 25);
            SetResist(ResistType.Poison, 60, 70);
            SetResist(ResistType.Energy, 40, 50);

            SetSkill(SkillName.Necromancy, 90.1, 100.0);
            SetSkill(SkillName.SpiritSpeak, 90.1, 105.0);
            SetSkill(SkillName.EvalInt, 90.1, 100.0);
            SetSkill(SkillName.Magery, 90.1, 100.0);
            SetSkill(SkillName.Meditation, 90.1, 100.0);
            SetSkill(SkillName.MagicResist, 90.1, 105.0);
            SetSkill(SkillName.Tactics, 75.1, 85.0);
            SetSkill(SkillName.Wrestling, 80.1, 100.0);
            SetSkill(SkillName.DetectHidden, 84.3);

            Fame = 9500;
            Karma = -9500;

            VirtualArmor = 44;

            PackItem(Loot.PackNecroReg(24, 45));
        }

        public Lifestealer(Serial serial)
            : base(serial)
        {
        }

        public override Poison PoisonImmunity => Poison.Lethal;

        public override int TreasureMapLevel => 4;
        public override int Meat => 3;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich, 2);
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
