using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a pixie corpse")]
    public class Pixie : BaseCreature
    {
        [Constructible]
        public Pixie()
            : base(AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4)
        {
            Name = NameList.RandomName("pixie");
            Body = 128;
            BaseSoundID = 0x467;

            SetStr(21, 30);
            SetDex(301, 400);
            SetInt(201, 250);

            SetHits(13, 18);

            SetDamage(9, 15);

            SetDamageType(ResistType.Physical, 100);

            SetResist(ResistType.Physical, 80, 90);
            SetResist(ResistType.Fire, 40, 50);
            SetResist(ResistType.Cold, 40, 50);
            SetResist(ResistType.Poison, 40, 50);
            SetResist(ResistType.Energy, 40, 50);

            SetSkill(SkillName.EvalInt, 90.1, 100.0);
            SetSkill(SkillName.Magery, 90.1, 100.0);
            SetSkill(SkillName.Meditation, 90.1, 100.0);
            SetSkill(SkillName.MagicResist, 100.5, 150.0);
            SetSkill(SkillName.Tactics, 10.1, 20.0);
            SetSkill(SkillName.Wrestling, 10.1, 12.5);

            Fame = 7000;
            Karma = 7000;

            VirtualArmor = 100;
        }

        public Pixie(Serial serial)
            : base(serial)
        {
        }

        public override bool InitialInnocent => true;
        public override HideType HideType => HideType.Spined;
        public override int Hides => 5;
        public override int Meat => 1;
        public override TribeType Tribe => TribeType.Fey;
        public override OppositionGroup OppositionGroup => OppositionGroup.FeyAndUndead;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.LowScrolls);
            AddLoot(LootPack.Gems, 2);
        }

        public override void OnDeath(Container CorpseLoot)
        {
            if (0.02 > Utility.RandomDouble())
                CorpseLoot.DropItem(Loot.RandomStatue());

            if (Utility.RandomDouble() < 0.3)
                CorpseLoot.DropItem(new PixieLeg());

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
