using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a dragon corpse")]
    public class SerpentineDragon : BaseCreature
    {
        [Constructible]
        public SerpentineDragon()
            : base(AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4)
        {
            Name = "a serpentine dragon";
            Body = 103;
            BaseSoundID = 362;

            SetStr(111, 140);
            SetDex(201, 220);
            SetInt(1001, 1040);

            SetHits(480);

            SetDamage(ResistType.Phys, 75, 0, 5, 12);
            SetDamage(ResistType.Pois, 25);

            SetResist(ResistType.Phys, 35, 40);
            SetResist(ResistType.Fire, 25, 35);
            SetResist(ResistType.Cold, 25, 35);
            SetResist(ResistType.Pois, 25, 35);
            SetResist(ResistType.Engy, 25, 35);

            SetSkill(SkillName.EvalInt, 100.1, 110.0);
            SetSkill(SkillName.Magery, 110.1, 120.0);
            SetSkill(SkillName.Meditation, 100.0);
            SetSkill(SkillName.MagicResist, 100.0);
            SetSkill(SkillName.Tactics, 50.1, 60.0);
            SetSkill(SkillName.Wrestling, 30.1, 100.0);
            SetSkill(SkillName.DetectHidden, 100.0);

            Fame = 15000;
            Karma = 15000;

            VirtualArmor = 36;

            Tamable = true;
            ControlSlots = 3;
            MinTameSkill = 108.0;

            SetSpecialAbility(SpecialAbility.DragonBreath);
        }

        public SerpentineDragon(Serial serial)
            : base(serial)
        {
        }

        public override bool ReacquireOnMovement => !Controlled;
        public override double BonusPetDamageScalar => Controlled ? 1.0 : (Core.SE) ? 3.0 : 1.0;
        public override bool AutoDispel => !Controlled;
        public override HideType HideType => HideType.Barbed;
        public override int Hides => 20;
        public override int Meat => 19;
        public override int Scales => 6;
        public override ScaleType ScaleType => (Utility.RandomBool() ? ScaleType.Black : ScaleType.White);
        public override int TreasureMapLevel => 4;
        public override bool CanAngerOnTame => true;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich, 2);
            AddLoot(LootPack.Gems, 2);
        }

        public override void OnDeath(Container CorpseLoot)
        {
            if (Core.ML && Utility.RandomDouble() < .33)
                CorpseLoot.DropItem(Engines.Plants.Seed.RandomPeculiarSeed(3));

            base.OnDeath(CorpseLoot);
        }

        public override int GetIdleSound() { return 0x2C4; }
        public override int GetAttackSound() { return 0x2C0; }
        public override int GetDeathSound() { return 0x2C1; }
        public override int GetAngerSound() { return 0x2C4; }
        public override int GetHurtSound() { return 0x2C3; }

        public override void OnGotMeleeAttack(Mobile attacker)
        {
            base.OnGotMeleeAttack(attacker);

            if (!Core.SE && 0.2 > Utility.RandomDouble() && attacker is BaseCreature creature)
            {
                BaseCreature c = creature;

                if (c.Controlled && c.ControlMaster != null)
                {
                    c.ControlTarget = c.ControlMaster;
                    c.ControlOrder = OrderType.Attack;
                    c.Combatant = c.ControlMaster;
                }
            }
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
