using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a fetid essence corpse")]
    public class FetidEssence : BaseCreature
    {
        [Constructible]
        public FetidEssence()
            : base(AIType.AI_Spellweaving, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a fetid essence";
            Body = 273;

            SetStr(101, 150);
            SetDex(210, 250);
            SetInt(451, 550);

            SetHits(551, 650);

            SetDamage(21, 25);

            SetDamageType(ResistanceType.Physical, 30);
            SetDamageType(ResistanceType.Poison, 70);

            SetResistance(ResistanceType.Physical, 40, 50);
            SetResistance(ResistanceType.Fire, 40, 50);
            SetResistance(ResistanceType.Cold, 40, 50);
            SetResistance(ResistanceType.Poison, 70, 90);
            SetResistance(ResistanceType.Energy, 75, 80);

            SetSkill(SkillName.Meditation, 91.4, 99.4);
            SetSkill(SkillName.EvalInt, 88.5, 92.3);
            SetSkill(SkillName.Magery, 97.9, 101.7);
            SetSkill(SkillName.Poisoning, 100);
            SetSkill(SkillName.Anatomy, 0, 4.5);
            SetSkill(SkillName.MagicResist, 103.5, 108.8);
            SetSkill(SkillName.Tactics, 81.0, 84.6);
            SetSkill(SkillName.Wrestling, 81.3, 83.9);

            Fame = 3700;
            Karma = -3700;

            SetAreaEffect(AreaEffect.EssenceOfDisease);
        }

        public FetidEssence(Serial serial)
            : base(serial)
        {
        }

        public override Poison HitPoison => Poison.Deadly;
        public override Poison PoisonImmunity => Poison.Deadly;

        public override void OnDeath(Container CorpseLoot)
        {
            for (int i = 0; i < Utility.RandomMinMax(0, 1); i++)
            {
                CorpseLoot.DropItem(Loot.RandomScroll(0, Loot.ArcanistScrollTypes.Length, SpellbookType.Arcanist));
            }

            base.OnDeath(CorpseLoot);
        }

        public override void GenerateLoot() 
        {
            AddLoot(LootPack.FilthyRich);
        }

        public override int GetAngerSound() { return 0x56D; }
        public override int GetIdleSound() { return 0x56B; }
        public override int GetAttackSound() { return 0x56C; }
        public override int GetHurtSound() { return 0x56C; }
        public override int GetDeathSound() { return 0x56E; }

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
