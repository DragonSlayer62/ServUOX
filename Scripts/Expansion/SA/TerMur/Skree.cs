using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a skree corpse")]
    public class Skree : BaseCreature
    {
        public override bool CanAngerOnTame => true;

        [Constructible]
        public Skree()
            : base(AIType.AI_Mystic, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a skree";
            Body = 733;

            SetStr(297, 330);
            SetDex(96, 124);
            SetInt(188, 260);

            SetHits(205, 300);

            SetDamage(5, 7);

            SetDamageType(ResistType.Phys, 100);

            SetResist(ResistType.Phys, 55, 65);
            SetResist(ResistType.Fire, 45, 55);
            SetResist(ResistType.Cold, 25, 40);
            SetResist(ResistType.Pois, 55, 65);
            SetResist(ResistType.Engy, 25, 40);

            SetSkill(SkillName.EvalInt, 90.6, 115.0);
            SetSkill(SkillName.Magery, 90.2, 114.2);
            SetSkill(SkillName.Meditation, 65.3, 75.0);
            SetSkill(SkillName.MagicResist, 75.1, 90.0);
            SetSkill(SkillName.Tactics, 20.2, 24.7);
            SetSkill(SkillName.Wrestling, 101.9, 117.9);
            SetSkill(SkillName.Mysticism, 80, 105.0);
            SetSkill(SkillName.Parry, 75, 85);

            Tamable = true;
            ControlSlots = 4;
            MinTameSkill = 95.1;
        }

        public Skree(Serial serial)
            : base(serial)
        {
        }

        public override int Meat => 3;

        public override MeatType MeatType => MeatType.Bird;

        public override int Hides => 5;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
        }

        public override int GetIdleSound()
        {
            return 1585;
        }

        public override int GetAngerSound()
        {
            return 1582;
        }

        public override int GetHurtSound()
        {
            return 1584;
        }

        public override int GetDeathSound()
        {
            return 1583;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            var version = reader.ReadInt();
        }
    }
}