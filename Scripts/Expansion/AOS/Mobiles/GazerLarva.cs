using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a gazer larva corpse")]
    public class GazerLarva : BaseCreature
    {
        [Constructible]
        public GazerLarva()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a gazer larva";
            Body = 778;
            BaseSoundID = 377;

            SetStr(76, 100);
            SetDex(51, 75);
            SetInt(56, 80);

            SetHits(36, 47);

            SetDamage(ResistType.Phys, 100, 0, 2, 9);

            SetResist(ResistType.Phys, 15, 25);

            SetSkill(SkillName.MagicResist, 70.0);
            SetSkill(SkillName.Tactics, 70.0);
            SetSkill(SkillName.Wrestling, 70.0);

            Fame = 900;
            Karma = -900;

            VirtualArmor = 25;

            PackItem(new Nightshade(Utility.RandomMinMax(2, 3)));
        }

        public GazerLarva(Serial serial)
            : base(serial)
        {
        }

        public override int Meat => 1;
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Poor);
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
