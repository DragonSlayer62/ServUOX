using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("an air elemental corpse")]
    public class SummonedAirElemental : BaseCreature
    {
        [Constructible]
        public SummonedAirElemental()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "an air elemental";
            Body = 13;
            Hue = 0x4001;
            BaseSoundID = 655;

            SetStr(200);
            SetDex(200);
            SetInt(100);

            SetHits(150);
            SetStam(50);

            SetDamage(6, 9);

            SetDamageType(ResistType.Physical, 50);
            SetDamageType(ResistType.Energy, 50);

            SetResist(ResistType.Physical, 40, 50);
            SetResist(ResistType.Fire, 30, 40);
            SetResist(ResistType.Cold, 35, 45);
            SetResist(ResistType.Poison, 50, 60);
            SetResist(ResistType.Energy, 70, 80);

            SetSkill(SkillName.Meditation, 90.0);
            SetSkill(SkillName.EvalInt, 70.0);
            SetSkill(SkillName.Magery, 70.0);
            SetSkill(SkillName.MagicResist, 60.0);
            SetSkill(SkillName.Tactics, 100.0);
            SetSkill(SkillName.Wrestling, 80.0);

            VirtualArmor = 40;
            ControlSlots = 2;
        }

        public SummonedAirElemental(Serial serial)
            : base(serial)
        {
        }

        public override double DispelDifficulty => 117.5;
        public override double DispelFocus => 45.0;

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            _ = reader.ReadInt();

            if (BaseSoundID == 263)
                BaseSoundID = 655;
        }
    }

    [CorpseName("a daemon corpse")]
    public class SummonedDaemon : BaseCreature
    {
        [Constructible]
        public SummonedDaemon()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = NameList.RandomName("daemon");
            Body = Core.AOS ? 10 : 9;
            BaseSoundID = 357;

            SetStr(200);
            SetDex(110);
            SetInt(150);

            SetDamage(14, 21);

            SetDamageType(ResistType.Physical, 0);
            SetDamageType(ResistType.Poison, 100);

            SetResist(ResistType.Physical, 45, 55);
            SetResist(ResistType.Fire, 50, 60);
            SetResist(ResistType.Cold, 20, 30);
            SetResist(ResistType.Poison, 70, 80);
            SetResist(ResistType.Energy, 40, 50);

            SetSkill(SkillName.EvalInt, 90.1, 100.0);
            SetSkill(SkillName.Meditation, 90.1, 100.0);
            SetSkill(SkillName.Magery, 90.1, 100.0);
            SetSkill(SkillName.MagicResist, 90.1, 100.0);
            SetSkill(SkillName.Tactics, 100.0);
            SetSkill(SkillName.Wrestling, 98.1, 99.0);

            VirtualArmor = 58;
            ControlSlots = Core.SE ? 4 : 5;
        }

        public SummonedDaemon(Serial serial)
            : base(serial)
        {
        }

        public override double DispelDifficulty => 125.0;
        public override double DispelFocus => 45.0;
        public override Poison PoisonImmunity => Poison.Regular;// TODO: Immune to poison?
        public override bool CanFly => true;

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

    [CorpseName("an earth elemental corpse")]
    public class SummonedEarthElemental : BaseCreature
    {
        [Constructible]
        public SummonedEarthElemental()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "an earth elemental";
            Body = 14;
            BaseSoundID = 268;

            SetStr(200);
            SetDex(70);
            SetInt(70);

            SetHits(180);

            SetDamage(14, 21);

            SetDamageType(ResistType.Physical, 100);

            SetResist(ResistType.Physical, 65, 75);
            SetResist(ResistType.Fire, 40, 50);
            SetResist(ResistType.Cold, 40, 50);
            SetResist(ResistType.Poison, 40, 50);
            SetResist(ResistType.Energy, 40, 50);

            SetSkill(SkillName.MagicResist, 65.0);
            SetSkill(SkillName.Tactics, 100.0);
            SetSkill(SkillName.Wrestling, 90.0);

            VirtualArmor = 34;
            ControlSlots = 2;
        }

        public SummonedEarthElemental(Serial serial)
            : base(serial)
        {
        }

        public override double DispelDifficulty => 117.5;
        public override double DispelFocus => 45.0;

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

    [CorpseName("a fire elemental corpse")]
    public class SummonedFireElemental : BaseCreature
    {
        [Constructible]
        public SummonedFireElemental()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a fire elemental";
            Body = 15;
            BaseSoundID = 838;

            SetStr(200);
            SetDex(200);
            SetInt(100);

            SetDamage(9, 14);

            SetDamageType(ResistType.Physical, 0);
            SetDamageType(ResistType.Fire, 100);

            SetResist(ResistType.Physical, 50, 60);
            SetResist(ResistType.Fire, 70, 80);
            SetResist(ResistType.Cold, 0, 10);
            SetResist(ResistType.Poison, 50, 60);
            SetResist(ResistType.Energy, 50, 60);

            SetSkill(SkillName.EvalInt, 90.0);
            SetSkill(SkillName.Magery, 90.0);
            SetSkill(SkillName.MagicResist, 85.0);
            SetSkill(SkillName.Tactics, 100.0);
            SetSkill(SkillName.Wrestling, 92.0);

            VirtualArmor = 40;
            ControlSlots = 4;

            AddItem(new LightSource());
        }

        public SummonedFireElemental(Serial serial)
            : base(serial)
        {
        }

        public override double DispelDifficulty => 117.5;
        public override double DispelFocus => 45.0;

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

    [CorpseName("a water elemental corpse")]
    public class SummonedWaterElemental : BaseCreature
    {
        [Constructible]
        public SummonedWaterElemental()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a water elemental";
            Body = 16;
            BaseSoundID = 278;

            SetStr(200);
            SetDex(70);
            SetInt(100);

            SetHits(165);

            SetDamage(12, 16);

            SetDamageType(ResistType.Physical, 0);
            SetDamageType(ResistType.Cold, 100);

            SetResist(ResistType.Physical, 50, 60);
            SetResist(ResistType.Fire, 20, 30);
            SetResist(ResistType.Cold, 70, 80);
            SetResist(ResistType.Poison, 45, 55);
            SetResist(ResistType.Energy, 40, 50);

            SetSkill(SkillName.Meditation, 90.0);
            SetSkill(SkillName.EvalInt, 80.0);
            SetSkill(SkillName.Magery, 80.0);
            SetSkill(SkillName.MagicResist, 75.0);
            SetSkill(SkillName.Tactics, 100.0);
            SetSkill(SkillName.Wrestling, 85.0);

            VirtualArmor = 40;
            ControlSlots = 3;
            CanSwim = true;
        }

        public SummonedWaterElemental(Serial serial)
            : base(serial)
        {
        }

        public override double DispelDifficulty => 117.5;
        public override double DispelFocus => 45.0;

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
