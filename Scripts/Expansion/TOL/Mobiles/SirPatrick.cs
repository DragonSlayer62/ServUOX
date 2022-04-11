using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a Sir Patrick corpse")]
    public class SirPatrick : SkeletalKnight
    {
        [Constructible]
        public SirPatrick()
        {
            Name = "Sir Patrick";
            Hue = 0x47E;

            SetStr(208, 319);
            SetDex(98, 132);
            SetInt(45, 91);

            SetHits(616, 884);

            SetDamage(15, 25);

            SetDamageType(ResistType.Physical, 40);
            SetDamageType(ResistType.Cold, 60);

            SetResist(ResistType.Physical, 55, 62);
            SetResist(ResistType.Fire, 40, 48);
            SetResist(ResistType.Cold, 71, 80);
            SetResist(ResistType.Poison, 40, 50);
            SetResist(ResistType.Energy, 50, 60);

            SetSkill(SkillName.Wrestling, 126.3, 136.5);
            SetSkill(SkillName.Tactics, 128.5, 143.8);
            SetSkill(SkillName.MagicResist, 102.8, 117.9);
            SetSkill(SkillName.Anatomy, 127.5, 137.2);

            Fame = 18000;
            Karma = -18000;

            for (int i = 0; i < Utility.RandomMinMax(0, 1); i++)
            {
                PackItem(Loot.RandomScroll(0, Loot.ArcanistScrollTypes.Length, SpellbookType.Arcanist));
            }

            SetSpecialAbility(SpecialAbility.LifeDrain);
        }

        public SirPatrick(Serial serial)
            : base(serial)
        {
        }

        public override bool CanBeParagon => false;

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.15)
                c.DropItem(new DisintegratingThesisNotes());

            if (Utility.RandomDouble() < 0.05)
                c.DropItem(new AssassinChest());
        }

        /*public override bool GivesMLMinorArtifact
        {
            get
            {
                return true;
            }
        }*/
        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich, 2);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
