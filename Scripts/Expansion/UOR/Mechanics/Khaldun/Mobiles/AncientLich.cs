using System;

namespace Server.Mobiles
{
    [CorpseName("an ancient liche's corpse")]
    public class AncientLich : BaseCreature
    {
        [Constructible]
        public AncientLich()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = NameList.RandomName("ancient lich");
            Body = 78;
            BaseSoundID = 412;

            SetStr(216, 305);
            SetDex(96, 115);
            SetInt(966, 1045);

            SetHits(560, 595);

            SetDamage(15, 27);

            SetDamageType(ResistType.Physical, 20);
            SetDamageType(ResistType.Cold, 40);
            SetDamageType(ResistType.Energy, 40);

            SetResist(ResistType.Physical, 55, 65);
            SetResist(ResistType.Fire, 25, 30);
            SetResist(ResistType.Cold, 50, 60);
            SetResist(ResistType.Poison, 50, 60);
            SetResist(ResistType.Energy, 25, 30);

            SetSkill(SkillName.EvalInt, 120.1, 130.0);
            SetSkill(SkillName.Magery, 120.1, 130.0);
            SetSkill(SkillName.Meditation, 100.1, 101.0);
            SetSkill(SkillName.Poisoning, 100.1, 101.0);
            SetSkill(SkillName.MagicResist, 175.2, 200.0);
            SetSkill(SkillName.Tactics, 90.1, 100.0);
            SetSkill(SkillName.Wrestling, 75.1, 100.0);
            SetSkill(SkillName.Necromancy, 120.1, 130.0);
            SetSkill(SkillName.SpiritSpeak, 120.1, 130.0);

            Fame = 23000;
            Karma = -23000;

            VirtualArmor = 60;
            PackItem(Loot.PackNecroReg(30, 275));
        }

        public AncientLich(Serial serial)
            : base(serial)
        {
        }

        public override OppositionGroup OppositionGroup => OppositionGroup.FeyAndUndead;
        public override bool Unprovokable => true;
        public override bool BleedImmunity => true;
        public override Poison PoisonImmunity => Poison.Lethal;
        public override int TreasureMapLevel => 5;
        public override int GetIdleSound()
        {
            return 0x19D;
        }

        public override int GetAngerSound()
        {
            return 0x175;
        }

        public override int GetDeathSound()
        {
            return 0x108;
        }

        public override int GetAttackSound()
        {
            return 0xE2;
        }

        public override int GetHurtSound()
        {
            return 0x28B;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich, 3);
            AddLoot(LootPack.MedScrolls, 2);
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
