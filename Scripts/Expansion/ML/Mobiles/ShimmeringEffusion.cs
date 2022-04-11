using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a shimmering effusion corpse")]
    public class ShimmeringEffusion : BasePeerless
    {
        [Constructible]
        public ShimmeringEffusion()
            : base(AIType.AI_Spellweaving, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a shimmering effusion";
            Body = 0x105;

            SetStr(500, 550);
            SetDex(350, 400);
            SetInt(1500, 1600);

            SetHits(20000);

            SetDamage(27, 31);

            SetDamageType(ResistType.Physical, 20);
            SetDamageType(ResistType.Fire, 20);
            SetDamageType(ResistType.Cold, 20);
            SetDamageType(ResistType.Poison, 20);
            SetDamageType(ResistType.Energy, 20);

            SetResist(ResistType.Physical, 60, 80);
            SetResist(ResistType.Fire, 60, 80);
            SetResist(ResistType.Cold, 60, 80);
            SetResist(ResistType.Poison, 60, 80);
            SetResist(ResistType.Energy, 60, 80);

            SetSkill(SkillName.Wrestling, 100.0, 105.0);
            SetSkill(SkillName.Tactics, 100.0, 105.0);
            SetSkill(SkillName.MagicResist, 150);
            SetSkill(SkillName.Magery, 150.0);
            SetSkill(SkillName.EvalInt, 150.0);
            SetSkill(SkillName.Meditation, 120.0);
            SetSkill(SkillName.Spellweaving, 120.0);

            Fame = 30000;
            Karma = -30000;

            PackResources(8);
            PackTalismans(5);
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.SuperBoss, 8);
            AddLoot(LootPack.Parrot, 2);
            AddLoot(LootPack.HighScrolls, 3);
            AddLoot(LootPack.MedScrolls, 3);
        }

        public override void OnDeath(Container c)
        {
            for (int i = 0; i < Utility.RandomMinMax(1, 6); i++)
            {
                c.DropItem(Loot.RandomScroll(0, Loot.ArcanistScrollTypes.Length, SpellbookType.Arcanist));
            }

            c.DropItem(new CapturedEssence());
            c.DropItem(new ShimmeringCrystals());

            if (Utility.RandomDouble() < 0.05)
            {
                switch (Utility.Random(4))
                {
                    case 0:
                        c.DropItem(new ShimmeringEffusionStatuette());
                        break;
                    case 1:
                        c.DropItem(new CorporealBrumeStatuette());
                        break;
                    case 2:
                        c.DropItem(new MantraEffervescenceStatuette());
                        break;
                    case 3:
                        c.DropItem(new FetidEssenceStatuette());
                        break;
                }
            }

            if (Utility.RandomDouble() < 0.05)
                c.DropItem(new FerretImprisonedInCrystal());

            if (Utility.RandomDouble() < 0.025)
                c.DropItem(new CrystallineRing());

            base.OnDeath(c);
        }

        public override bool AutoDispel => true;
        public override int TreasureMapLevel => 5;
        public override bool HasFireRing => true;
        public override double FireRingChance => 0.1;

        public override int GetIdleSound() { return 0x1BF; }
        public override int GetAttackSound() { return 0x1C0; }
        public override int GetHurtSound() { return 0x1C1; }
        public override int GetDeathSound() { return 0x1C2; }

        #region Helpers
        public override bool CanSpawnHelpers => true;
        public override int MaxHelpersWaves => 4;
        public override double SpawnHelpersChance => 0.1;

        public override void SpawnHelpers()
        {
            int amount = 1;

            if (Altar != null)
                amount = Altar.Fighters.Count;

            if (amount > 5)
                amount = 5;

            for (int i = 0; i < amount; i++)
            {
                switch (Utility.Random(3))
                {
                    case 0:
                        SpawnHelper(new MantraEffervescence(), 2);
                        break;
                    case 1:
                        SpawnHelper(new CorporealBrume(), 2);
                        break;
                    case 2:
                        SpawnHelper(new FetidEssence(), 2);
                        break;
                }
            }
        }

        #endregion

        public ShimmeringEffusion(Serial serial)
            : base(serial)
        {
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
