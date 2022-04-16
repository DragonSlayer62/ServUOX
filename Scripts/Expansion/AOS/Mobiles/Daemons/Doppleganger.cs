using System;

namespace Server.Mobiles
{
    [CorpseName("a doppleganger corpse")]
    public class Doppleganger : BaseCreature
    {
        [Constructible]
        public Doppleganger()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a doppleganger";
            Body = 0x309;
            BaseSoundID = 0x451;

            SetStr(81, 110);
            SetDex(56, 75);
            SetInt(81, 105);

            SetHits(101, 120);

            SetDamage(ResistType.Phys, 100, 0, 8, 12);

            SetResist(ResistType.Phys, 50, 60);
            SetResist(ResistType.Fire, 10, 20);
            SetResist(ResistType.Cold, 40, 50);
            SetResist(ResistType.Pois, 50, 60);
            SetResist(ResistType.Engy, 30, 40);

            SetSkill(SkillName.MagicResist, 75.1, 85.0);
            SetSkill(SkillName.Tactics, 70.1, 80.0);
            SetSkill(SkillName.Wrestling, 80.1, 90.0);

            Fame = 1000;
            Karma = -1000;

            VirtualArmor = 55;
        }

        public Doppleganger(Serial serial)
            : base(serial)
        {
        }

        public override int Hides => 6;
        public override int Meat => 1;
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            _ = reader.ReadInt();
        }
    }
}