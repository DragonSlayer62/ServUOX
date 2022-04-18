using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a cu sidhe corpse")]
    public class CuSidhe : BaseMount
    {
        public override double HealChance => 1.0;

        [Constructible]
        public CuSidhe()
            : this("a cu sidhe")
        {
        }

        [Constructible]
        public CuSidhe(string name)
            : base(name, 277, 0x3E91, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            double chance = Utility.RandomDouble() * 23301;

            if (chance <= 1)
                Hue = Utility.RandomList(0x487, 0x489);
            else if (chance <= 301)
                Hue = Utility.RandomList(0x657, 0x515, 0x4B1, 0x481, 0x482, 0x455);
            else if (chance <= 3301)
                Hue = Utility.RandomList(0x97A, 0x978, 0x901, 0x8AC, 0x5A7, 0x527);
            /*
            if (chance <= 1)
                Hue = 0x489;
            else if (chance < 50)
                Hue = Utility.RandomList(0x657, 0x515, 0x4B1, 0x481, 0x482, 0x455);
            else if (chance < 500)
                Hue = Utility.RandomList(0x97A, 0x978, 0x901, 0x8AC, 0x5A7, 0x527);
            */

            SetStr(1200, 1225);
            SetDex(150, 170);
            SetInt(250, 285);

            SetHits(1010, 1275);

            SetDamage(21, 28);

            SetDamageType(ResistType.Phys, 0);
            SetDamageType(ResistType.Cold, 50);
            SetDamageType(ResistType.Engy, 50);

            SetResist(ResistType.Phys, 50, 65);
            SetResist(ResistType.Fire, 25, 45);
            SetResist(ResistType.Cold, 70, 85);
            SetResist(ResistType.Pois, 30, 50);
            SetResist(ResistType.Engy, 70, 85);

            SetSkill(SkillName.Wrestling, 90.1, 96.8);
            SetSkill(SkillName.Tactics, 90.3, 99.3);
            SetSkill(SkillName.MagicResist, 75.3, 90.0);
            SetSkill(SkillName.Anatomy, 65.5, 69.4);
            SetSkill(SkillName.Healing, 72.2, 98.9);

            Fame = 5000;  //Guessing here
            Karma = 5000;  //Guessing here

            Tamable = true;
            ControlSlots = 4;
            MinTameSkill = 101.1;

            PackItem(Loot.PackGold(500, 800));

            SetWeaponAbility(WeaponAbility.BleedAttack);
        }

        public CuSidhe(Serial serial)
            : base(serial)
        {
        }

        public override int TreasureMapLevel => 5;

        public override FoodType FavoriteFood => FoodType.FruitsAndVegies;
        public override bool CanAngerOnTame => true;
        public override bool StatLossAfterTame => true;
        public override int Hides => 10;
        public override int Meat => 3;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.AosFilthyRich, 5);
        }

        public override void OnAfterTame(Mobile tamer)
        {
            if (Owners.Count == 0 && PetTrainingHelper.Enabled)
            {
                if (RawStr > 0)
                    RawStr = (int)Math.Max(1, RawStr * 0.5);

                if (RawDex > 0)
                    RawDex = (int)Math.Max(1, RawDex * 0.5);

                if (HitsMaxSeed > 0)
                    HitsMaxSeed = (int)Math.Max(1, HitsMaxSeed * 0.5);

                Hits = Math.Min(HitsMaxSeed, Hits);
                Stam = Math.Min(RawDex, Stam);
            }
            else
            {
                base.OnAfterTame(tamer);
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.Race != Race.Elf && from == ControlMaster && from.IsPlayer())
            {
                Item pads = from.FindItemOnLayer(Layer.Shoes);

                if (pads is PadsOfTheCuSidhe)
                    from.SendLocalizedMessage(1071981); // Your boots allow you to mount the Cu Sidhe.
                else
                {
                    from.SendLocalizedMessage(1072203); // Only Elves may use 
                    return;
                }
            }

            base.OnDoubleClick(from);
        }

        public override int GetIdleSound() => 0x578;
        public override int GetAttackSound() => 0x577;
        public override int GetAngerSound() => 0x579;
        public override int GetHurtSound() => 0x57A;
        public override int GetDeathSound() => 0x576;

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