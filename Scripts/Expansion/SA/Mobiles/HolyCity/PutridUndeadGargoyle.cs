/* Based on Gargoyle, still no infos on Undead Gargoyle... Have to get also the correct body ID */
using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a putrid undead gargoyle corpse")]
    public class PutridUndeadGargoyle : BaseCreature
    {
        [Constructible]
        public PutridUndeadGargoyle()
            : base(AIType.AI_Mystic, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a putrid undead gargoyle";
            Body = 722;
            BaseSoundID = 372;
            Hue = 1778;

            SetStr(525);
            SetDex(120, 125);
            SetInt(1145);

            SetHits(660, 665);

            SetDamage(21, 30);

            SetDamageType(ResistType.Physical, 20);
            SetDamageType(ResistType.Cold, 40);
            SetDamageType(ResistType.Energy, 40);

            SetResist(ResistType.Physical, 55, 60);
            SetResist(ResistType.Fire, 33);
            SetResist(ResistType.Cold, 50);
            SetResist(ResistType.Poison, 50, 55);
            SetResist(ResistType.Energy, 45, 50);

            SetSkill(SkillName.EvalInt, 125.0);
            SetSkill(SkillName.Magery, 127.0);
            SetSkill(SkillName.Mysticism, 100.0);
            SetSkill(SkillName.Meditation, 105.0, 108.0);
            SetSkill(SkillName.MagicResist, 180.0, 187.0);
            SetSkill(SkillName.Tactics, 100.0);
            SetSkill(SkillName.Wrestling, 100.0, 102.0);

            Fame = 3500;
            Karma = -3500;

            VirtualArmor = 32;

            if (0.05 > Utility.RandomDouble())
                PackItem(new TatteredAncientScroll());

            if (0.10 > Utility.RandomDouble())
                PackItem(new InfusedGlassStave());

            if (0.15 > Utility.RandomDouble())
                PackItem(new AncientPotteryFragments());
        }

        public PutridUndeadGargoyle(Serial serial)
            : base(serial)
        {
        }

        public override int Meat => 1;
        public override bool Unprovokable => true;
        public override bool BardImmunity => true;
        public override Poison PoisonImmunity => Poison.Deadly;
        public override Poison HitPoison => Poison.Deadly;
        public override void GenerateLoot()
        {
            AddLoot(LootPack.AosFilthyRich, 5);
            AddLoot(LootPack.MedScrolls);
            AddLoot(LootPack.Gems, Utility.RandomMinMax(1, 4));
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