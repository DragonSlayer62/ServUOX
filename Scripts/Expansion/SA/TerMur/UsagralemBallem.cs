using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("an usagralem ballem corpse")]
    public class UsagralemBallem : BaseVoidCreature
    {
        public override VoidEvolution Evolution => VoidEvolution.Killing;
        public override int Stage => 3;

        [Constructible]
        public UsagralemBallem()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "usagrallem ballem";
            Hue = 2071;
            Body = 318;
            BaseSoundID = 0x165;

            SetStr(900, 1000);
            SetDex(1028);
            SetInt(1000, 1100);

            SetHits(2000, 2200);
            SetMana(5000);

            SetDamage(17, 21);

            SetDamageType(ResistType.Physical, 20);
            SetDamageType(ResistType.Fire, 20);
            SetDamageType(ResistType.Cold, 20);
            SetDamageType(ResistType.Poison, 20);
            SetDamageType(ResistType.Energy, 20);

            SetResist(ResistType.Physical, 30, 40);
            SetResist(ResistType.Fire, 40, 60);
            SetResist(ResistType.Cold, 40, 60);
            SetResist(ResistType.Poison, 40, 60);
            SetResist(ResistType.Energy, 40, 60);

            SetSkill(SkillName.MagicResist, 80.0, 90.0);
            SetSkill(SkillName.Tactics, 80.0, 90.0);
            SetSkill(SkillName.Wrestling, 80.0, 90.0);

            Fame = 18000;
            Karma = -18000;

            VirtualArmor = 64;

            PackItem(new DaemonBone(30));

            SetWeaponAbility(WeaponAbility.DoubleStrike);
            SetWeaponAbility(WeaponAbility.WhirlwindAttack);
            SetWeaponAbility(WeaponAbility.CrushingBlow);
        }

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.30)
            {
                c.DropItem(new AncientPotteryFragments());
            }
        }

        public UsagralemBallem(Serial serial)
            : base(serial)
        {
        }

        public override bool IgnoreYoungProtection => Core.ML;
        public override bool BardImmunity => !Core.SE;
        public override bool Unprovokable => Core.SE;
        public override bool AreaPeaceImmunity => Core.SE;
        public override Poison PoisonImmunity => Poison.Lethal;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich, 1);
            AddLoot(LootPack.FilthyRich, 2);
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
