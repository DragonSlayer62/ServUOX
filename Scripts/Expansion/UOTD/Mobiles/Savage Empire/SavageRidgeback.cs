namespace Server.Mobiles
{
    [CorpseName("a savage ridgeback corpse")]
    public class SavageRidgeback : BaseMount
    {
        [Constructible]
        public SavageRidgeback()
            : this("a savage ridgeback")
        {
        }

        [Constructible]
        public SavageRidgeback(string name)
            : base(name, 188, 0x3EB8, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            BaseSoundID = 0x3F3;

            SetStr(58, 100);
            SetDex(56, 75);
            SetInt(16, 30);

            SetHits(41, 54);
            SetMana(0);

            SetDamage(ResistType.Phys, 100, 0, 3, 5);

            SetResist(ResistType.Phys, 15, 20);
            SetResist(ResistType.Fire, 10, 15);
            SetResist(ResistType.Cold, 15, 20);
            SetResist(ResistType.Pois, 10, 15);
            SetResist(ResistType.Engy, 10, 15);

            SetSkill(SkillName.MagicResist, 25.3, 40.0);
            SetSkill(SkillName.Tactics, 29.3, 44.0);
            SetSkill(SkillName.Wrestling, 35.1, 45.0);

            Fame = 300;
            Karma = 0;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 83.1;
        }

        public SavageRidgeback(Serial serial)
            : base(serial)
        {
        }

        public override int Meat => 1;
        public override int Hides => 12;
        public override HideType HideType => HideType.Spined;
        public override FoodType FavoriteFood => FoodType.FruitsAndVegies | FoodType.GrainsAndHay;

        public override bool OverrideBondingReqs()
        {
            return true;
        }

        public override double GetControlChance(Mobile m, bool useBaseSkill)
        {
            if (PetTrainingHelper.Enabled)
            {
                var profile = PetTrainingHelper.GetAbilityProfile(this);

                if (profile != null && profile.HasCustomized())
                {
                    return base.GetControlChance(m, useBaseSkill);
                }
            }

            return 1.0;
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
