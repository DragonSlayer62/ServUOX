using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a reapers corpse")]
    public class Reaper : BaseCreature
    {
        [Constructible]
        public Reaper()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a reaper";
            Body = 47;
            BaseSoundID = 442;

            SetStr(66, 215);
            SetDex(66, 75);
            SetInt(101, 250);

            SetHits(40, 129);
            SetStam(0);

            SetDamage(ResistType.Phys, 80, 0, 9, 11);
            SetDamage(ResistType.Pois, 20);

            SetResist(ResistType.Phys, 35, 45);
            SetResist(ResistType.Fire, 15, 25);
            SetResist(ResistType.Cold, 10, 20);
            SetResist(ResistType.Pois, 40, 50);
            SetResist(ResistType.Engy, 30, 40);

            SetSkill(SkillName.EvalInt, 90.1, 100.0);
            SetSkill(SkillName.Magery, 90.1, 100.0);
            SetSkill(SkillName.MagicResist, 100.1, 125.0);
            SetSkill(SkillName.Tactics, 45.1, 60.0);
            SetSkill(SkillName.Wrestling, 50.1, 60.0);

            Fame = 3500;
            Karma = -3500;

            VirtualArmor = 40;
        }

        public Reaper(Serial serial)
            : base(serial)
        {
        }

        public override Poison PoisonImmunity => Poison.Greater;
        public override int TreasureMapLevel => 2;
        public override bool DisallowAllMoves => true;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
        }

        public override void OnDeath(Container CorpseLoot)
        {
            CorpseLoot.DropItem(new Log(10));
            CorpseLoot.DropItem(new MandrakeRoot(5));
            base.OnDeath(CorpseLoot);
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
