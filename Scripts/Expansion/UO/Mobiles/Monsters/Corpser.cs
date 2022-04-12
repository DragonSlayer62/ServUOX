using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a corpser corpse")]
    public class Corpser : BaseCreature
    {
        [Constructible]
        public Corpser()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a corpser";
            Body = 8;
            BaseSoundID = 684;

            SetStr(156, 180);
            SetDex(26, 45);
            SetInt(26, 40);

            SetHits(94, 108);
            SetMana(0);

            SetDamage(ResistType.Phys, 60, 0, 10, 23);
            SetDamage(ResistType.Pois, 40);

            SetResist(ResistType.Phys, 15, 20);
            SetResist(ResistType.Fire, 15, 25);
            SetResist(ResistType.Cold, 10, 20);
            SetResist(ResistType.Pois, 20, 30);

            SetSkill(SkillName.MagicResist, 15.1, 20.0);
            SetSkill(SkillName.Tactics, 45.1, 60.0);
            SetSkill(SkillName.Wrestling, 45.1, 60.0);

            Fame = 1000;
            Karma = -1000;

            VirtualArmor = 18;
        }

        public Corpser(Serial serial)
            : base(serial)
        {
        }

        public override Poison PoisonImmunity => Poison.Lesser;
        public override bool DisallowAllMoves => true;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Meager);
        }

        public override void OnDeath(Container CorpseLoot)
        {
            if (0.25 > Utility.RandomDouble())
                CorpseLoot.DropItem(new Board(10));
            else
                CorpseLoot.DropItem(new Log(10));

            CorpseLoot.DropItem(new MandrakeRoot(3));

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
