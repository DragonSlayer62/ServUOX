using System;

namespace Server.Mobiles
{
    [CorpseName("an acid elemental corpse")]
    public class ToxicElemental : BaseCreature
    {
        [Constructible]
        public ToxicElemental()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "an acid elemental";
            Body = 0x9E;
            BaseSoundID = 278;

            SetStr(326, 355);
            SetDex(66, 85);
            SetInt(271, 295);

            SetHits(196, 213);

            SetDamage(9, 15);

            SetDamageType(ResistType.Physical, 25);
            SetDamageType(ResistType.Fire, 50);
            SetDamageType(ResistType.Energy, 25);

            SetResist(ResistType.Physical, 45, 55);
            SetResist(ResistType.Fire, 40, 50);
            SetResist(ResistType.Cold, 20, 30);
            SetResist(ResistType.Poison, 10, 20);
            SetResist(ResistType.Energy, 30, 40);

            SetSkill(SkillName.Anatomy, 30.3, 60.0);
            SetSkill(SkillName.EvalInt, 70.1, 85.0);
            SetSkill(SkillName.Magery, 70.1, 85.0);
            SetSkill(SkillName.MagicResist, 60.1, 75.0);
            SetSkill(SkillName.Tactics, 80.1, 90.0);
            SetSkill(SkillName.Wrestling, 70.1, 90.0);

            Fame = 10000;
            Karma = -10000;

            VirtualArmor = 40;
        }

        public ToxicElemental(Serial serial)
            : base(serial)
        {
        }

        public override bool BleedImmunity => true;
        public override Poison HitPoison => Poison.Lethal;
        public override double HitPoisonChance => 0.6;
        public override int TreasureMapLevel => Core.AOS ? 2 : 3;
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
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
            int version = reader.ReadInt();
        }
    }
}