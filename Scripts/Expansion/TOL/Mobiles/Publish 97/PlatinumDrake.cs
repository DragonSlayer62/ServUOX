using System;

namespace Server.Mobiles
{
    [CorpseName("a platinum drake corpse")]
    public class PlatinumDrake : BaseCreature, IElementalCreature
    {
        private ElementType m_Type;

        public ElementType ElementType => m_Type;

        [Constructible]
        public PlatinumDrake()
            : this((ElementType)Utility.Random(5))
        {
        }

        [Constructible]
        public PlatinumDrake(ElementType type)
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            m_Type = type;

            switch (type)
            {
                case ElementType.Physical:
                    Body = 0x589;
                    Hue = 0;
                    SetDamageType(ResistType.Physical, 100);
                    break;
                case ElementType.Fire:
                    Body = 0x58A;
                    Hue = 33929;
                    SetDamageType(ResistType.Physical, 0);
                    SetDamageType(ResistType.Fire, 100);
                    break;
                case ElementType.Cold:
                    Body = 0x58A;
                    Hue = 34134;
                    SetDamageType(ResistType.Physical, 0);
                    SetDamageType(ResistType.Cold, 100);
                    break;
                case ElementType.Poison:
                    Body = 0x58A;
                    Hue = 34136;
                    SetDamageType(ResistType.Physical, 0);
                    SetDamageType(ResistType.Poison, 100);
                    break;
                case ElementType.Energy:
                    Body = 0x58A;
                    Hue = 34141;
                    SetDamageType(ResistType.Physical, 0);
                    SetDamageType(ResistType.Energy, 100);
                    break;
            }

            Name = "Platinum Drake";
            Female = true;
            BaseSoundID = 362;

            SetStr(400, 430);
            SetDex(133, 152);
            SetInt(101, 140);

            SetHits(241, 258);

            SetDamage(11, 17);

            SetResist(ResistType.Physical, 30, 50);
            SetResist(ResistType.Fire, 30, 50);
            SetResist(ResistType.Cold, 30, 50);
            SetResist(ResistType.Poison, 40, 50);
            SetResist(ResistType.Energy, 30, 50);

            SetSkill(SkillName.MagicResist, 65.1, 80.0);
            SetSkill(SkillName.Tactics, 65.1, 90.0);
            SetSkill(SkillName.Wrestling, 65.1, 80.0);
            SetSkill(SkillName.DetectHidden, 50.0, 60.0);
            SetSkill(SkillName.Focus, 5.0, 20.0);

            Fame = 5500;
            Karma = -5500;

            VirtualArmor = 46;

            Tamable = true;
            ControlSlots = 2;
            MinTameSkill = 85.0;

            PackItem(Loot.PackReg(3));
        }

        public PlatinumDrake(Serial serial)
            : base(serial)
        {
        }

        public static TrainingDefinition _PoisonDrakeDefinition;

        public override TrainingDefinition TrainingDefinition
        {
            get
            {
                if (m_Type == ElementType.Poison)
                {
                    if (_PoisonDrakeDefinition == null)
                    {
                        _PoisonDrakeDefinition = new TrainingDefinition(GetType(), Class.None, MagicalAbility.Dragon2, PetTrainingHelper.SpecialAbilityNone, PetTrainingHelper.WepAbility2, PetTrainingHelper.AreaEffectArea2, 2, 5);
                    }

                    return _PoisonDrakeDefinition;
                }

                return base.TrainingDefinition;
            }
        }

        public override bool ReacquireOnMovement => !Controlled;
        public override int TreasureMapLevel => 2;
        public override int Meat => 10;
        public override int DragonBlood => 8;
        public override int Hides => 22;
        public override HideType HideType => HideType.Horned;
        public override int Scales => 2;
        public override ScaleType ScaleType => ScaleType.Black;
        public override FoodType FavoriteFood => FoodType.Meat | FoodType.Fish;
        public override bool CanFly => true;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
            AddLoot(LootPack.MedScrolls, 2);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);

            writer.Write((int)m_Type);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            m_Type = (ElementType)reader.ReadInt();
        }
    }
}
