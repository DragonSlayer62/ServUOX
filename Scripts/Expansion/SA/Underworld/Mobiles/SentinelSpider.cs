using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a sentinel spider corpse")]
    public class SentinelSpider : BaseCreature
    {
        [Constructible]
        public SentinelSpider() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a Sentinel spider";
            Body = 0x9d;
            Hue = 1141;
            BaseSoundID = 0x388;

            SetStr(95, 100);
            SetDex(140, 145);
            SetInt(40, 45);

            SetHits(260, 265);

            SetDamage(15, 22);

            SetDamageType(ResistType.Phys, 100);

            SetResist(ResistType.Phys, 45, 50);
            SetResist(ResistType.Fire, 30, 35);
            SetResist(ResistType.Cold, 30, 35);
            SetResist(ResistType.Pois, 70, 75);
            SetResist(ResistType.Engy, 30, 35);

            SetSkill(SkillName.Anatomy, 85.0, 90.0);
            SetSkill(SkillName.MagicResist, 88.5, 90.0);
            SetSkill(SkillName.Tactics, 102.9, 105.0);
            SetSkill(SkillName.Wrestling, 119.1, 120.0);
            SetSkill(SkillName.Poisoning, 101.0, 102.0);

            Fame = 775;
            Karma = -775;

            VirtualArmor = 28;

            SetWeaponAbility(WeaponAbility.ArmorIgnore);
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Meager);
            AddLoot(LootPack.Poor);
        }

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (!Controlled && Utility.RandomDouble() < 0.03)
                c.DropItem(new LuckyCoin());
        }

        public override FoodType FavoriteFood => FoodType.Meat;
        public override PackInstinct PackInstinct => PackInstinct.Arachnid;

        public SentinelSpider(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            if (version == 0)
            {
                Body = 0x9d;
                Hue = 1141;
            }

            if (BaseSoundID == 387)
                BaseSoundID = 0x388;
        }
    }
}