using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a ballem corpse")]
    public class Ballem : BaseVoidCreature
    {
        public override VoidEvolution Evolution => VoidEvolution.Killing;
        public override int Stage => 2;

        [Constructible]
        public Ballem()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "ballem";
            Body = 304;
            Hue = 2071;
            BaseSoundID = 684;

            SetStr(991);
            SetDex(1001);
            SetInt(243);

            SetHits(500, 600);

            SetDamage(10, 15);

            SetDamageType(ResistType.Phys, 20);
            SetDamageType(ResistType.Fire, 20);
            SetDamageType(ResistType.Cold, 20);
            SetDamageType(ResistType.Pois, 20);
            SetDamageType(ResistType.Engy, 20);

            SetResist(ResistType.Phys, 30, 50);
            SetResist(ResistType.Fire, 40, 50);
            SetResist(ResistType.Cold, 20, 30);
            SetResist(ResistType.Pois, 100);
            SetResist(ResistType.Engy, 30, 40);

            SetSkill(SkillName.MagicResist, 70.0, 80.0);
            SetSkill(SkillName.Tactics, 50.1, 60.0);
            SetSkill(SkillName.Wrestling, 70.1, 80.0);
            SetSkill(SkillName.Anatomy, 0.0, 10.0);

            Fame = 1800;
            Karma = -1800;

            VirtualArmor = 54;

            PackItem(new DaemonBone(15));

            SetWeaponAbility(WeaponAbility.CrushingBlow);
        }

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.10)
            {
                c.DropItem(new AncientPotteryFragments());
            }
        }

        public Ballem(Serial serial)
            : base(serial)
        {
        }

        public override Poison PoisonImmunity => Poison.Lethal;
        public override bool Unprovokable => true;
        public override bool BardImmunity => true;
        public override bool CanRummageCorpses => true;
        public override bool BleedImmunity => true;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
            AddLoot(LootPack.Average);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
