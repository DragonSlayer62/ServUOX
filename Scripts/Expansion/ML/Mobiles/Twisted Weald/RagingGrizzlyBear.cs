namespace Server.Mobiles
{
    [CorpseName("a grizzly bear corpse")]
    public class RagingGrizzlyBear : BaseCreature
    {
        [Constructible]
        public RagingGrizzlyBear()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "a raging grizzly bear";
            Body = 212;
            BaseSoundID = 0xA3;

            SetStr(1251, 1550);
            SetDex(801, 1050);
            SetInt(151, 400);

            SetHits(751, 930);
            SetMana(0);

            SetDamage(ResistType.Phys, 100, 0, 18, 23);

            SetResist(ResistType.Phys, 50, 70);
            SetResist(ResistType.Cold, 30, 50);
            SetResist(ResistType.Pois, 10, 20);
            SetResist(ResistType.Engy, 10, 20);

            SetSkill(SkillName.Wrestling, 73.4, 88.1);
            SetSkill(SkillName.Tactics, 73.6, 110.5);
            SetSkill(SkillName.MagicResist, 32.8, 54.6);
            SetSkill(SkillName.Anatomy, 0, 0);

            Fame = 10000;
            Karma = 10000;

            VirtualArmor = 24;

            Tamable = false;
        }

        public RagingGrizzlyBear(Serial serial)
            : base(serial)
        {
        }

        public override int Meat => 4;
        public override int Hides => 32;
        public override PackInstinct PackInstinct => PackInstinct.Bear;

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
