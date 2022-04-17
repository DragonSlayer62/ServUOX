using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a deathwatchbeetle hatchling corpse")]
    [TypeAlias("Server.Mobiles.DeathWatchBeetleHatchling")]
    public class DeathwatchBeetleHatchling : BaseCreature
    {
        [Constructible]
        public DeathwatchBeetleHatchling()
            : base(AIType.AI_Melee, Core.ML ? FightMode.Aggressor : FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a deathwatch beetle hatchling";
            Body = 242;

            SetStr(26, 50);
            SetDex(41, 52);
            SetInt(21, 30);

            SetHits(51, 60);
            SetMana(20);

            SetDamage(ResistType.Phys, 100, 0, 2, 8);

            SetResist(ResistType.Phys, 35, 40);
            SetResist(ResistType.Fire, 15, 30);
            SetResist(ResistType.Cold, 15, 30);
            SetResist(ResistType.Pois, 20, 40);
            SetResist(ResistType.Engy, 20, 35);

            SetSkill(SkillName.Wrestling, 30.1, 40.0);
            SetSkill(SkillName.Tactics, 47.1, 57.0);
            SetSkill(SkillName.MagicResist, 30.1, 38.0);
            SetSkill(SkillName.Anatomy, 20.1, 24.0);

            Fame = 700;
            Karma = -700;

            if (Utility.RandomBool())
            {
                Item i = Loot.RandomReagent();
                i.Amount = 3;
                PackItem(i);
            }

            switch (Utility.Random(12))
            {
                case 0:
                    PackItem(new LeatherGorget());
                    break;
                case 1:
                    PackItem(new LeatherGloves());
                    break;
                case 2:
                    PackItem(new LeatherArms());
                    break;
                case 3:
                    PackItem(new LeatherLegs());
                    break;
                case 4:
                    PackItem(new LeatherCap());
                    break;
                case 5:
                    PackItem(new LeatherChest());
                    break;
                default:
                    PackItem(new LeatherChest());
                    break;
            }
        }

        public DeathwatchBeetleHatchling(Serial serial)
            : base(serial)
        {
        }

        public override int Hides => 8;
        public override int GetAngerSound() => 0x4F3;

        public override int GetIdleSound() => 0x4F2;

        public override int GetAttackSound() => 0x4F1;

        public override int GetHurtSound() => 0x4F4;

        public override int GetDeathSound() => 0x4F0;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.LowScrolls, 1);
            AddLoot(LootPack.Potions, 1);
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
