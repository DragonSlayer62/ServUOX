using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a crystal vortex corpse")]
    public class CrystalVortex : AirElemental
    {
        [Constructible]
        public CrystalVortex()
            : base()
        {
            Name = "a crystal vortex";
            Body = 0xD;
            Hue = 0x2B2;

            SetStr(800, 900);
            SetDex(500, 600);
            SetInt(200);

            SetHits(350, 400);
            SetMana(0);

            SetDamage(ResistType.Phys, 0, 0, 15, 20);
            SetDamage(ResistType.Cold, 50);
            SetDamage(ResistType.Engy, 50);

            SetResist(ResistType.Phys, 60, 80);
            SetResist(ResistType.Fire, 0, 10);
            SetResist(ResistType.Cold, 70, 80);
            SetResist(ResistType.Pois, 40, 50);
            SetResist(ResistType.Engy, 60, 90);

            SetSkill(SkillName.MagicResist, 120.0);
            SetSkill(SkillName.Tactics, 120.0);
            SetSkill(SkillName.Wrestling, 120.0);

            Fame = 17000;
            Karma = -17000;
        }

        public CrystalVortex(Serial serial)
            : base(serial)
        {
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich, 2);
            AddLoot(LootPack.Parrot);
            AddLoot(LootPack.MedScrolls);
            AddLoot(LootPack.HighScrolls);
        }

        public override void OnDeath(Container c)
        {
            for (int i = 0; i < Utility.RandomMinMax(0, 2); i++)
            {
                c.DropItem(Loot.RandomScroll(0, Loot.ArcanistScrollTypes.Length, SpellbookType.Arcanist));
            }

            if (Utility.RandomDouble() < 0.75)
                c.DropItem(new CrystallineFragments());

            if (Utility.RandomDouble() < 0.06)
                c.DropItem(new JaggedCrystals());

            base.OnDeath(c);
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